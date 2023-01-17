package humanPAWPatrol;

public abstract class Human {

    protected final String name;
    protected final Integer age;

    public Human(String name, Integer age) {
        this.name = name;
        this.age = age;
    }

    @Override
    public String toString() {
        return name + ", возраст: " + age;
    }

    @Override
    public boolean equals(Object obj) {

        if (obj instanceof Human human) {
            return name.equals(human.name) && age.equals(human.age);
        }

        return false;
    }

    @Override
    public int hashCode() {
        return name.hashCode();
    }
}