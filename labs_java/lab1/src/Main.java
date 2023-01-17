import java.util.Scanner;

public class Main {
    private static final int MIN_COMMANDS_AMOUNT = 1;
    private static final int MAX_COMMANDS_AMOUNT = 10000;
    private static final int MIN_OBSTACLES_AMOUNT = 0;
    private static final int MAX_OBSTACLES_AMOUNT = 10000;
    private static final int MIN_OBSTACLE = -3 * MAX_OBSTACLES_AMOUNT;
    private static final int MAX_OBSTACLE = 3 * MAX_OBSTACLES_AMOUNT;

    public static void main(String[] args) {

        int[] commands = readCommands();
        int[][] obstacles = readObstacles();
        WalkingRobotSimulation walkingRobotSimulation = new WalkingRobotSimulation(commands, obstacles);
        walkingRobotSimulation.makeMoves();
        int[] farthestPoint = walkingRobotSimulation.getFarthestPoint();
        System.out.print(farthestPoint[0] * farthestPoint[0] + farthestPoint[1] * farthestPoint[1]);
    }

    private static int[] readCommands() {

        Scanner scanner = new Scanner(System.in);

        int commandsLength = MIN_COMMANDS_AMOUNT - 1;
        System.out.print("Введите количество команд: ");
        if (scanner.hasNextInt()) {
            commandsLength = scanner.nextInt();
        }
        scanner.nextLine();

        while (MIN_COMMANDS_AMOUNT > commandsLength || commandsLength > MAX_COMMANDS_AMOUNT) {

            System.out.printf("Количество команд должно быть равно целому числу в диапазоне [%d, %d].%nВведите еще раз: ", MIN_COMMANDS_AMOUNT, MAX_COMMANDS_AMOUNT);
            if (scanner.hasNextInt()) {
                commandsLength = scanner.nextInt();
            }
            scanner.nextLine();
        }

        int[] commands = new int[commandsLength];
        for (int i = 0; i < commandsLength; i++) {

            System.out.printf("Введите команду %d: ", i + 1);
            if (scanner.hasNextInt()) {
                commands[i] = scanner.nextInt();
            }
            scanner.nextLine();

            while (-2 > commands[i] || commands[i] > 9 || commands[i] == 0) {

                System.out.printf("Команда должна быть равна -2, -1 или целому числу в диапазоне [1, 9].%nВведите еще раз: ");
                if (scanner.hasNextInt()) {
                    commands[i] = scanner.nextInt();
                }
                scanner.nextLine();
            }
        }

        return commands;
    }

    private static int[][] readObstacles() {

        Scanner scanner = new Scanner(System.in);

        int obstaclesLength = MIN_OBSTACLES_AMOUNT - 1;
        System.out.print("Введите количество препятствий: ");
        if (scanner.hasNextInt()) {
            obstaclesLength = scanner.nextInt();
        }
        scanner.nextLine();

        while (MIN_OBSTACLES_AMOUNT > obstaclesLength || obstaclesLength > MAX_OBSTACLES_AMOUNT) {

            System.out.printf("Количество препятствий должно быть равно целому числу в диапазоне [%d, %d].%nВведите еще раз: ", MIN_OBSTACLES_AMOUNT, MAX_OBSTACLES_AMOUNT);
            if (scanner.hasNextInt()) {
                obstaclesLength = scanner.nextInt();
            }
            scanner.nextLine();
        }

        int[][] obstacles = new int[obstaclesLength][2];
        for (int i = 0; i < obstaclesLength; i++) {
            obstacles[i][0] = MIN_OBSTACLE - 1;
            obstacles[i][1] = MIN_OBSTACLE - 1;

            System.out.printf("Введите координаты x и y для препятствия %d через пробел: ", i + 1);
            if (scanner.hasNextInt()) {
                obstacles[i][0] = scanner.nextInt();
            }
            if (scanner.hasNextInt()) {
                obstacles[i][1] = scanner.nextInt();
            }
            scanner.nextLine();

            while (MIN_OBSTACLE > obstacles[i][0] || obstacles[i][0] > MAX_OBSTACLE
                    || MIN_OBSTACLE > obstacles[i][1] || obstacles[i][1] > MAX_OBSTACLE) {

                System.out.printf("Координаты препятствия должны быть равны целым числам в диапазоне [%d, %d].%nВведите еще раз: ", MIN_OBSTACLE, MAX_OBSTACLE);
                if (scanner.hasNextInt()) {
                    obstacles[i][0] = scanner.nextInt();
                }
                if (scanner.hasNextInt()) {
                    obstacles[i][1] = scanner.nextInt();
                }
                scanner.nextLine();
            }
        }

        return obstacles;
    }
}