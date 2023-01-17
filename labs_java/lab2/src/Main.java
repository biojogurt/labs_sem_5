import java.util.ArrayList;
import java.util.List;

import dogPAWPatrol.*;
import genericPAWPatrol.*;
import humanPAWPatrol.*;

public class Main {
    public static void main(String[] args) {

        PAWPatrolMember humanMember = new PAWPatrolHumanMember("Райдер", 10, "лидер", "красный вездеход", "Отважным щенкам все по зубам и отряд щенков к делу готов!");
        PAWPatrolMember allergicMember = new AllergicPAWPatrolDogMember("Гонщик", "немецкая овчарка",7, "мент", "синий внедорожник", "сверхскорость", "Смело за дело!", "кот");
        PAWPatrolMember dogMember1 = new PAWPatrolDogMember("Маршалл", "далматинец",6, "пожарный", "красный пожарный фургон", "манипуляция огнем", "Готов зажечь!");
        PAWPatrolMember dogMember2 = new PAWPatrolDogMember("Скай", "кокапу",7, "летчик", "розовый вертолёт", "манипуляция воздухом", "Небо зовёт в полёт!");
        PAWPatrolMember roboticMember = new RoboticPAWPatrolDogMember("Робо-пес", "водитель");

        List<PAWPatrolMember> members = new ArrayList<>();
        members.add(humanMember);
        members.add(allergicMember);
        members.add(dogMember1);
        members.add(dogMember2);
        members.add(roboticMember);

        for (PAWPatrolMember member : members) {

            System.out.printf(member.toString() + "%n");
            member.useVehicle();
            System.out.println();
            member.sayCatchphrase();
            System.out.println();

            if (member instanceof PAWPatrolDogMember dog) {
                dog.useSpecialPower();
                System.out.println();
            }

            if (member instanceof AllergicPAWPatrolDogMember allergic) {
                allergic.smellAllergy();
                System.out.println();
            }
        }
    }
}