package dogPAWPatrol;

public abstract class Dog {

    protected final String name;
    protected final String breed;
    protected final Integer age;

    public Dog(String name, String breed, Integer age) {
        this.name = name;
        this.breed = breed;
        this.age = age;
    }

    @Override
    public String toString() {
        return name + ": " + breed + ", возраст: " + age;
    }

    @Override
    public boolean equals(Object obj) {

        if (obj instanceof Dog dog) {
            return name.equals(dog.name) && breed.equals(dog.breed) && age.equals(dog.age);
        }

        return false;
    }

    @Override
    public int hashCode() {
        return name.hashCode();
    }
}