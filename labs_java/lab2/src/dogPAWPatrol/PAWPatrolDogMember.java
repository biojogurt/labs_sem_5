package dogPAWPatrol;

import genericPAWPatrol.*;

public class PAWPatrolDogMember extends Dog implements PAWPatrolMember {

    protected final String role;
    protected final String vehicle;
    protected final String specialPower;
    protected final String catchphrase;

    public PAWPatrolDogMember(String name, String breed, Integer age,
                               String role, String vehicle, String specialPower, String catchphrase) {

        super(name, breed, age);
        this.role = role;
        this.vehicle = vehicle;
        this.specialPower = specialPower;
        this.catchphrase = catchphrase;
    }

    public void useSpecialPower() {
        System.out.print(name + " использует: " + specialPower);
    }

    @Override
    public void useVehicle() {
        System.out.print(name + " использует: " + vehicle);
    }

    @Override
    public void sayCatchphrase() {
        System.out.print(catchphrase);
    }

    @Override
    public String toString() {
        return super.toString() + "%nРоль: " + role;
    }

    @Override
    public boolean equals(Object obj) {

        if (obj instanceof PAWPatrolDogMember pawPatrolDogMember) {
            return super.equals(obj) && role.equals(pawPatrolDogMember.role)
                    && vehicle.equals(pawPatrolDogMember.vehicle)
                    && specialPower.equals(pawPatrolDogMember.specialPower)
                    && catchphrase.equals(pawPatrolDogMember.catchphrase);
        }

        return false;
    }
}