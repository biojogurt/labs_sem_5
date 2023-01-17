package ru.vsu.logic;

import ru.vsu.entity.ExamResult;
import ru.vsu.entity.Student;

import java.util.Collection;
import java.util.Comparator;
import java.util.List;
import java.util.Set;
import java.util.stream.Collectors;

public class StudentServiceImpl implements StudentService {

    @Override
    public List<String> getAdultStudentsLastNameSorted(Collection<Student> students) {
        return students
                .stream()
                .filter(x -> x.getAge() >= 18)
                .map(Student::getLastName)
                .sorted()
                .toList();
    }

    @Override
    public Set<Student> getExcellentStudents(Collection<Student> students) {
        return students
                .stream()
                .filter(x -> x
                        .getExamResults()
                        .stream()
                        .allMatch(y -> y.getMark() == 5))
                .collect(Collectors.toSet());
    }

    @Override
    public Double getAverageMark(Collection<Student> students) {
        return students
                .stream()
                .map(Student::getExamResults)
                .flatMap(Set::stream)
                .collect(Collectors.averagingDouble(ExamResult::getMark));
    }

    @Override
    public Student findYoungestStudent(Collection<Student> students) {
        return students
                .stream()
                .min(Comparator.comparingInt(Student::getAge))
                .orElse(null);
    }
}