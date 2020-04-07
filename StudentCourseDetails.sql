SELECT Course.Title, Enrollment.grade
FROM Student 
JOIN Enrollment
ON Enrollment.StudentID = Student.StudentID
JOIN Course
ON Course.CourseID = Enrollment.CourseID
WHERE Student.StudentID = 3