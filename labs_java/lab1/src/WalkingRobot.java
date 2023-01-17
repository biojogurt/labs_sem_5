public class WalkingRobot {
    public enum Directions {
        north, east, south, west;

        public Directions previous() {
            return values()[(this.ordinal() + 3) % values().length];
        }

        public Directions next() {
            return values()[(this.ordinal() + 1) % values().length];
        }
    }

    private Directions currentDirection = Directions.north;
    private int[] currentCoordinates = {0, 0};

    public Directions getDirection() {
        return currentDirection;
    }

    public void setDirection(Directions direction) {
        currentDirection = direction;
    }

    public int[] getCoordinates() {
        return currentCoordinates;
    }

    public void setCoordinates(int[] coordinates) {
        currentCoordinates = coordinates;
    }
}