; Дано предложение. Между словами добавить по одному пробелу

.model tiny

.data
    buffer                    DB 99, 0, 100 dup('$')
    sentence                  DB 100 dup('$')
    sentence_length           DB 0
    new_sentence              DB 100 dup('$')
    
    string_newline            DB 13, 10, '$'
    string_input_sentence     DB 'Input sentence', 13, 10, '$'
    string_your_sentence      DB 'Your sentence', 13, 10, '$'
    string_new_sentence       DB 'New sentence', 13, 10, '$'

.code
start:
    CLD
    
    LEA  AX, string_newline
    PUSH AX
    LEA  AX, string_input_sentence
    PUSH AX
    LEA  AX, sentence
    PUSH AX
    LEA  AX, sentence_length
    PUSH AX
    LEA  AX, buffer
    PUSH AX
    
    CALL read_sentence
    
    POP  AX
    POP  AX
    POP  AX
    POP  AX
    POP  AX
    
    LEA  AX, string_your_sentence
    PUSH AX
    LEA  AX, sentence
    PUSH AX
    
    CALL write_sentence
    
    POP  AX
    POP  AX
    POP  AX
    
    LEA  AX, sentence
    PUSH AX
    MOV  AL, sentence_length
    MOV  AH, 0
    PUSH AX
    LEA  AX, new_sentence
    PUSH AX
    
    CALL add_spaces
    
    POP  AX
    POP  AX
    POP  AX
    
    LEA  AX, string_new_sentence
    PUSH AX
    LEA  AX, new_sentence
    PUSH AX
    
    CALL write_sentence
    
    POP  AX
    POP  AX
    POP  AX
    
    MOV  AX, 4c00h
    INT  21h

add_spaces PROC
    PUSH BP
    MOV  BP, SP
    PUSH AX
    PUSH BX
    PUSH CX
    PUSH DX
    PUSH DI
    PUSH SI
    
    MOV  SI, [BP + 8]     ; sentence
    MOV  DI, [BP + 4]     ; edited_sentence
    
    MOV  AL, ' '
    MOV  BX, 0
    
skip_space:
    XCHG SI, DI
    MOV  DX, DI
    MOV  CX, [BP + 6]     ; sentence_length
    REPE SCASB
    DEC  DI
    SUB  DX, DI
    NEG  DX
    MOV  CX, DX
    XCHG SI, DI
    REP STOSB
    JMP  add_space
    
skip_word:
    CMP  [SI], '.'
    JE   over
    CMP  [SI], ' '
    JE   skip_space
    MOVSB
    JMP  skip_word
    
add_space:
    CMP  [SI], '.'
    JE   over
    CMP  BX, 0
    JE   first_word
    STOSB
    JMP  skip_word
    
first_word:
    MOV  BX, 1
    JMP  skip_word
    
over:
    MOVSB
    
    POP  SI
    POP  DI
    POP  DX
    POP  CX
    POP  BX
    POP  AX
    POP  BP
    RET
add_spaces ENDP

write_sentence PROC
    PUSH BP
    MOV  BP, SP
    PUSH AX
    PUSH DX
    PUSH SI
    
    MOV  AH, 9
    
    MOV  DX, [BP + 6]     ; string_your_sentence
    INT  21h
    
    MOV  DX, [BP + 4]     ; sentence
    INT  21h
    
    POP  SI
    POP  DX
    POP  AX
    POP  BP
    RET
write_sentence ENDP

read_sentence PROC
    PUSH BP
    MOV  BP, SP
    PUSH AX
    PUSH BX
    PUSH CX
    PUSH DX
    PUSH DI
    PUSH SI
    
    MOV  AH, 9
    MOV  DX, [BP + 10]    ; string_input_sentence
    INT  21h
    
    MOV  AH, 10
    MOV  DX, [BP + 4]     ; buffer
    INT  21h
    
    MOV  SI, DX
    
    MOV  BL, [SI + 1]
    MOV  BH, 0
    MOV  DI, [BP + 6]     ; sentence_length
    MOV  [DI], BX
    
    MOV  [SI + BX + 3], 10
    
    ADD  SI, 2
    MOV  CX, BX
    ADD  CX, 2
    MOV  DI, [BP + 8]     ; sentence
    REP MOVSB
    
    MOV  AH, 9
    MOV  DX, [BP + 12]    ; string_newline
    INT  21h
    
    POP  SI
    POP  DI
    POP  DX
    POP  CX
    POP  BX
    POP  AX
    POP  BP
    RET
read_sentence ENDP