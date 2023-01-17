package dogPAWPatrol;

public final class RoboticPAWPatrolDogMember extends PAWPatrolDogMember {

    public RoboticPAWPatrolDogMember(String name, String role) {

        super(name, "робот", null, role, null, null, null);
    }

    @Override
    public void useSpecialPower() {
        System.out.print(name + "не имеет суперспособности! Он просто робот :)");
    }

    @Override
    public void useVehicle() {
        System.out.print(name + " не имеет собственного транспорта :(");
    }

    @Override
    public void sayCatchphrase() {
        System.out.print(name + " не умеет разговаривать! Он гавкает в ответ :)");
    }

    @Override
    public String toString() {
        return name + ": " + breed + "%nРоль: " + role;
    }
}