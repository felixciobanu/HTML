"""
Flask: Using templates
"""

from setup_db import select_students, select_courses, select_grades, select_students_given, \
    select_grades_given_student, add_student, add_grade
from sqlite3 import Error
import sqlite3
from flask import Flask, render_template, request, redirect, url_for, g
import random
app = Flask(__name__)


DATABASE = './database.db'


def get_db():
    db = getattr(g, '_database', None)
    if db is None:
        db = g._database = sqlite3.connect(DATABASE)
    return db

@app.teardown_appcontext
def close_connection(exception):
    db = getattr(g, '_database', None)
    if db is not None:
        db.close()


@app.route("/")
def index():
    # get the database connection
    conn = get_db()
    return render_template("index.html", 
                            # select_students executes SELECT SQL statement on database connetion
                            # returns list of students
                            students=select_students(conn),
                            courses=select_courses(conn))


# Add additional routes here.
@app.route('/student/<int:student_no>')
def student(student_no):
    conn = get_db()
    cur = conn.cursor()
    try:
        dataHolder = []
        sql = "SELECT grades.student_no, grades.course_id, grades.grade, students.name FROM grades, students WHERE students.student_no=? and grades.student_no=?"
        cur.execute(sql, (student_no, student_no,))
        for (student_no, course_id, grade, name) in cur:
            dataHolder.append({
                "student_no": student_no,
                "course_id": course_id,
                "grade": grade,
                "name": name
            })
        return render_template("student.html", data=dataHolder, givenStudent=student_no)
    finally:
        dataHolder = []
        cur.close()


@app.route('/course/<course_code>')
def course(course_code):
    conn = get_db()
    cur = conn.cursor()
    try:
        dataHolder = []
        dataToCount = []
        sql = "SELECT grades.student_no, grades.course_id, grades.grade, courses.name FROM grades, courses WHERE courses.id=? and grades.course_id=? ORDER BY grades.grade ASC"
        cur.execute(sql, (course_code, course_code,))
        for (student_no, course_id, grade, courseN) in cur:
            dataHolder.append({
                "student_no": student_no,
                "course_id": course_id,
                "grade": grade,
                "courseN": courseN
            })
            dataToCount.append(grade)
        return render_template("course.html", dataC=dataToCount, data=dataHolder, givenCourse=course_code)
    finally:
        dataHolder = []
        cur.close()

@app.route('/add_student')
def course_add_student():
    conn = get_db()
    return render_template("student_form.html",
                           # select_students executes SELECT SQL statement on database connetion
                           # returns list of students
                           students=select_students(conn),
                           courses=select_courses(conn))


@app.route('/add_grades')
def course_add_grades():
    conn = get_db()
    return render_template("addGrade.html",
                            # select_students executes SELECT SQL statement on database connetion
                            # returns list of students
                            students=select_students(conn),
                            courses=select_courses(conn))


@app.route("/add_error", methods=["GET", "POST"])
def addStudentToDb():
    conn = get_db()
    navn = request.form.get("navn", "")
    studnum = random.randrange(100000, 999999)


    if navn:
        try:
            add_student(conn, studnum, navn)
        except Error:
            return render_template("error.html", msg="Please fill in name.")
        finally:
            return redirect(url_for("index"))
    else:
        return render_template("error.html", msg="Please fill in name.")


@app.route("/add_grade_error", methods=["GET", "POST"])
def addGrades():
    conn = get_db()
    course = request.form.get("course", "")
    studentnr = request.form.get("stud", "")
    grade = request.form.get("grade", "")
    if course and studentnr and grade:
        try:
            add_grade(conn, course, studentnr, grade)
        except Error:
            return render_template("addGrade.html", courses=select_courses(conn), students=select_students(conn),
                                   grades=select_grades(conn), msg="Legg til Course, Studentnummer, eller Grade.")
        finally:
            return render_template("addGradeDone.html", grade=grade, studnum=studentnr, courseid=course,
                                   courses=select_courses(conn), students=select_students(conn), grades=select_grades(conn))
    else:
        return render_template("addGrade.html", students=select_students(conn), courses=select_courses(conn),
                               grades=select_grades(conn), msg="Legg til Course, Studentnummer, eller Grade.")


if __name__ == "__main__":
    app.run(debug=True)
