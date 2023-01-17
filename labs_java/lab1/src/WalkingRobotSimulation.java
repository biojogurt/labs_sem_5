public class WalkingRobotSimulation {
    private final WalkingRobot walkingRobot = new WalkingRobot();
    private final int[] commands;
    private final int[][] obstacles;
    private int[] farthestPoint = null;

    public WalkingRobotSimulation(int[] commands, int[][] obstacles) {

        this.commands = commands;
        this.obstacles = obstacles;
    }

    public int[] getFarthestPoint() {
        return farthestPoint;
    }

    public void makeMoves() {

        for (int command : commands) {
            WalkingRobot.Directions direction = walkingRobot.getDirection();

            switch (command) {
                case -1 -> walkingRobot.setDirection(direction.next());
                case -2 -> walkingRobot.setDirection(direction.previous());
                default -> makeMove(command);
            }
        }
    }

    private void makeMove(int command) {

        WalkingRobot.Directions direction = walkingRobot.getDirection();
        int[] coordinates = walkingRobot.getCoordinates();
        int[] obstacleOnPath = findObstacleOnPath(command);

        switch (direction) {
            case north -> {
                if (obstacleOnPath != null) {
                    coordinates[1] = obstacleOnPath[1] - 1;
                } else {
                    coordinates[1] += command;
                }
            }
            case east -> {
                if (obstacleOnPath != null) {
                    coordinates[0] = obstacleOnPath[0] - 1;
                } else {
                    coordinates[0] += command;
                }
            }
            case south -> {
                if (obstacleOnPath != null) {
                    coordinates[1] = obstacleOnPath[1] + 1;
                } else {
                    coordinates[1] -= command;
                }
            }
            case west -> {
                if (obstacleOnPath != null) {
                    coordinates[0] = obstacleOnPath[0] + 1;
                } else {
                    coordinates[0] -= command;
                }
            }
        }

        if (farthestPoint == null
                || Math.abs(coordinates[0]) >= Math.abs(farthestPoint[0])
                && Math.abs(coordinates[1]) >= Math.abs(farthestPoint[1])) {
            farthestPoint = coordinates.clone();
        }

        walkingRobot.setCoordinates(coordinates);
    }

    private int[] findObstacleOnPath(int command) {

        WalkingRobot.Directions direction = walkingRobot.getDirection();
        int[] coordinates = walkingRobot.getCoordinates();
        int[] obstacleOnPath = null;

        switch (direction) {
            case north -> {
                for (int[] obstacle : obstacles) {
                    if (obstacle[0] == coordinates[0]
                            && obstacle[1] > coordinates[1]
                            && obstacle[1] <= coordinates[1] + command
                            && (obstacleOnPath == null
                            || obstacleOnPath[1] > obstacle[1])) {
                        obstacleOnPath = obstacle;
                    }
                }
            }
            case east -> {
                for (int[] obstacle : obstacles) {
                    if (obstacle[1] == coordinates[1]
                            && obstacle[0] > coordinates[0]
                            && obstacle[0] <= coordinates[0] + command
                            && (obstacleOnPath == null
                            || obstacleOnPath[0] > obstacle[0])) {
                        obstacleOnPath = obstacle;
                    }
                }
            }
            case south -> {
                for (int[] obstacle : obstacles) {
                    if (obstacle[0] == coordinates[0]
                            && obstacle[1] < coordinates[1]
                            && obstacle[1] >= coordinates[1] - command
                            && (obstacleOnPath == null
                            || obstacleOnPath[1] < obstacle[1])) {
                        obstacleOnPath = obstacle;
                    }
                }
            }
            case west -> {
                for (int[] obstacle : obstacles) {
                    if (obstacle[1] == coordinates[1]
                            && obstacle[0] < coordinates[0]
                            && obstacle[0] >= coordinates[0] - command
                            && (obstacleOnPath == null
                            || obstacleOnPath[0] < obstacle[0])) {
                        obstacleOnPath = obstacle;
                    }
                }
            }
        }

        return obstacleOnPath;
    }
}