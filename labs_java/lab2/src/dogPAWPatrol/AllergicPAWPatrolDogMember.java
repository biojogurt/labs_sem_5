package dogPAWPatrol;

public final class AllergicPAWPatrolDogMember extends PAWPatrolDogMember {

    private final String allergy;

    public AllergicPAWPatrolDogMember(String name, String breed, int age,
                                      String role, String vehicle, String specialPower, String catchphrase,
                                      String allergy) {

        super(name, breed, age, role, vehicle, specialPower, catchphrase);
        this.allergy = allergy;
    }

    public void smellAllergy() {
        System.out.print(name + " учуял: " + allergy + ". Чихает!");
    }

    @Override
    public boolean equals(Object obj) {

        if (obj instanceof AllergicPAWPatrolDogMember allergicPAWPatrolDogMember) {
            return super.equals(obj) && allergy.equals(allergicPAWPatrolDogMember.allergy);
        }

        return false;
    }
}