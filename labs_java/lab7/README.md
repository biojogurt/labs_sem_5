Создать аннотацию для класса @Component.  
Создать аннотацию для поля @Autowired.  
Создать класс Context, который при инициализации будет:  
1) создавать экземпляры классов, помеченных как @Component;  
2) инициализировать поля значениями из контекста, если они помечены @Autowired  
Контекст должен позволять получить экземпляр по классу.  

@Component  
class Service1 {  
}  

@Component  
class Service2 {  
    @Autowired  
    Service1 service1;  
}  

main() {  
    Context context = ...  
    Service2 service2 = context.get(Service2.class)  
}  
