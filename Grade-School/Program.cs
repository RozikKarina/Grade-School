using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private readonly Dictionary<int, List<string>> _grades;

    public GradeSchool()
    {
        _grades = new Dictionary<int, List<string>>();
    }

    // Adds a student to a specified grade, ensuring they are only added once to any grade
    public bool Add(string student, int grade)
    {
        if (_grades.Values.Any(g => g.Contains(student)))
        {
            // Student already exists in the roster in any grade
            return false;
        }

        if (!_grades.ContainsKey(grade))
        {
            _grades[grade] = new List<string>();
        }

        _grades[grade].Add(student);
        _grades[grade].Sort();
        return true;
    }

    // Returns a sorted list of all students in all grades, by grade then by name
    public IEnumerable<string> Roster()
    {
        return _grades
            .OrderBy(g => g.Key)              // Sort by grade
            .SelectMany(g => g.Value)         // Get all students within each grade
            .ToList();
    }

    // Returns a sorted list of students in a specific grade, or an empty list if no students
    public IEnumerable<string> Grade(int grade)
    {
        return _grades.ContainsKey(grade) ? _grades[grade] : new List<string>();
    }
}