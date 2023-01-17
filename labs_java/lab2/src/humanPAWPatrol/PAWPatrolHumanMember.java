package humanPAWPatrol;

import genericPAWPatrol.*;

public class PAWPatrolHumanMember extends Human implements PAWPatrolMember {

    protected final String role;
    protected final String vehicle;
    protected final String catchphrase;

    public PAWPatrolHumanMember(String name, Integer age,
                                String role, String vehicle, String catchphrase) {

        super(name, age);
        this.role = role;
        this.vehicle = vehicle;
        this.catchphrase = catchphrase;
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

        if (obj instanceof PAWPatrolHumanMember pawPatrolHumanMember) {
            return super.equals(obj) && role.equals(pawPatrolHumanMember.role)
                    && vehicle.equals(pawPatrolHumanMember.vehicle)
                    && catchphrase.equals(pawPatrolHumanMember.catchphrase);
        }

        return false;
    }
}