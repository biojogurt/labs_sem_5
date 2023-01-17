; Упорядочены ли по возрастанию все положительные значения

.model tiny

.data
    array                    DW -1, -122, 0, -41, -55
    array_length             DW 5
    string_sorted            DB 'Sorted', 13, 10, '$'
    string_not_sorted        DB 'Not sorted', 13, 10, '$'
    string_no_positive_elems DB 'No positive elements found', 13, 10, '$'

.code
start:
    LEA  DI, array
    MOV  CX, array_length
    MOV  AX, 1       
    MOV  BX, 0

check_if_sorted:
    CMP  [DI], 0
    JLE  not_positive
    CMP  [DI], AX
    JL   not_sorted
    MOV  BX, 1
    MOV  AX, [DI]
    ADD  DI, 2
    LOOP check_if_sorted
    JMP  output

not_positive:
    ADD  DI, 2
    LOOP check_if_sorted
    JMP  output

not_sorted:
    MOV  BX, 2

output:
    MOV  AH, 9
    CMP  BX, 0
    JE   output_no_positive_elems
    CMP  BX, 1
    JE   output_sorted
    LEA  DX, string_not_sorted
    JMP  print

output_no_positive_elems:
    LEA  DX, string_no_positive_elems
    JMP  print

output_sorted:
    LEA  DX, string_sorted

print:
    INT  21h
    RET

END start