package ru.vsu.logic;

import ru.vsu.entity.Student;
import ru.vsu.entity.Subject;
import ru.vsu.entity.Teacher;

import java.math.BigDecimal;
import java.util.Collection;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

public class TeacherServiceImpl implements TeacherService {
    @Override
    public List<String> getSingleSubjectLecturerFio(Collection<Teacher> teachers) {
        return teachers
                .stream()
                .filter(x -> x.getSubjects().size() == 1)
                .map(Teacher::getFullName)
                .toList();
    }

    @Override
    public Map<String, List<Student>> getTeacherNameToSupervisedStudentsMap(Collection<Student> students) {
        return students
                .stream()
                .filter(x -> x.getSupervisor() != null)
                .sorted((x, y) -> x.getLastName().equals(y.getLastName())
                        ? x.getFirstName().compareTo(y.getFirstName())
                        : x.getLastName().compareTo(y.getLastName()))
                .collect(Collectors.groupingBy(Student::getSupervisor))
                .entrySet()
                .stream()
                .collect(Collectors.toMap(
                        x -> x.getKey().getFullName(),
                        Map.Entry::getValue
                ));
    }

    @Override
    public BigDecimal getTeachersSalarySum(Collection<Teacher> teachers) {
        return teachers
                .stream()
                .map(Teacher::getSalary)
                .reduce(BigDecimal.ZERO, BigDecimal::add);
    }

    @Override
    public String findTeacherBySubject(Collection<Teacher> teachers, Subject subject) {
        return teachers
                .stream()
                .filter(x -> x.getSubjects().contains(subject))
                .map(Teacher::getFullName)
                .findFirst()
                .orElse(null);
    }
}