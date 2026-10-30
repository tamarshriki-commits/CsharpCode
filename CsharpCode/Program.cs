using CsharpCode;

namespace CsharpCode
{
    internal class Program
    {
        static StudentManager studentManager = new StudentManager();
        static CourseManager courseManager = new CourseManager();
        static ClassroomManager classroomManager = new ClassroomManager();
        static LecturerManager lecturerManager = new LecturerManager();
        static CourseOfferingManager offeringManager = new CourseOfferingManager();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== CYBER COLLEGE =====");
                Console.WriteLine("1. Student Management");
                Console.WriteLine("2. Course Management");
                Console.WriteLine("3. Classroom Management");
                Console.WriteLine("4. Lecturer Management");
                Console.WriteLine("5. Open Course Offering");
                Console.WriteLine("6. Show All Course Offerings");
                Console.WriteLine("0. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddStudent();
                }
                else if (choice == "2")
                {
                    AddCourse();
                }
                else if (choice == "3")
                {
                    AddClassroom();
                }
                else if (choice == "4")
                {
                    AddLecturer();
                }
                else if (choice == "5")
                {
                    OpenCourseOffering();
                }
                else if (choice == "6")
                {
                    ShowOfferings();
                }
                else if (choice == "0")
                {
                    running = false;
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }
            }
        }

        // =========================
        // STUDENT MANAGEMENT
        // =========================

        static void AddStudent()
        {
            Console.WriteLine("\n--- Add New Student ---");

            string firstName = ReadText("First name: ");
            string lastName = ReadText("Last name: ");
            string id = ReadText("ID: ");

            DateTime birthDate = ReadDate(
                "Birth date (dd/MM/yyyy): ");

            Console.WriteLine("\nChoose study track:");
            Console.WriteLine("1. Practical Engineer");
            Console.WriteLine("2. Bachelor");
            Console.WriteLine("3. Master");

            int trackChoice = ReadInt("Choice: ", 1, 3);

            StudyTrack track = StudyTrack.PracticalEngineer;

            if (trackChoice == 1)
            {
                track = StudyTrack.PracticalEngineer;
            }
            else if (trackChoice == 2)
            {
                track = StudyTrack.Bachelor;
            }
            else if (trackChoice == 3)
            {
                track = StudyTrack.Master;
            }

            Console.WriteLine("\nChoose profession:");
            Console.WriteLine("1. Software Engineering");
            Console.WriteLine("2. Computer Science");
            Console.WriteLine("3. Cyber");

            int professionChoice = ReadInt("Choice: ", 1, 3);

            Profession profession = Profession.Cyber;

            if (professionChoice == 1)
            {
                profession = Profession.SoftwareEngineering;
            }
            else if (professionChoice == 2)
            {
                profession = Profession.ComputerScience;
            }
            else if (professionChoice == 3)
            {
                profession = Profession.Cyber;
            }

            Student student = new Student(
                firstName, lastName, id,
                birthDate, track, profession);

            if (studentManager.AddStudent(student))
            {
                Console.WriteLine("Student added successfully!");
            }
            else
            {
                Console.WriteLine("A student with this ID already exists!");
            }
        }

        // =========================
        // COURSE MANAGEMENT
        // =========================

        static void AddCourse()
        {
            Console.WriteLine("\n--- Add New Course ---");

            string code = ReadText("Course code: ");
            string name = ReadText("Course name: ");

            int credits = ReadInt("Credits: ", 1, 100);

            string faculty = ReadText("Parent faculty: ");

            int hours = ReadInt("Study hours: ", 1, 10000);

            Course course = new Course(
                code, name, credits, faculty, hours);

            if (courseManager.AddCourse(course))
            {
                Console.WriteLine("Course added successfully!");
            }
            else
            {
                Console.WriteLine("Course code already exists!");
            }
        }

        // =========================
        // CLASSROOM MANAGEMENT
        // =========================

        static void AddClassroom()
        {
            Console.WriteLine("\n--- Add New Classroom ---");

            string id = ReadText("Classroom ID: ");
            string building = ReadText("Building: ");

            int seats = ReadInt("Number of seats: ", 1, 10000);

            Classroom classroom = new Classroom(
                id, building, seats);

            if (classroomManager.AddClassroom(classroom))
            {
                Console.WriteLine("Classroom added successfully!");
            }
            else
            {
                Console.WriteLine("This classroom already exists!");
            }
        }

        // =========================
        // LECTURER MANAGEMENT
        // =========================

        static void AddLecturer()
        {
            Console.WriteLine("\n--- Add New Lecturer ---");

            string firstName = ReadText("First name: ");
            string lastName = ReadText("Last name: ");
            string id = ReadText("ID: ");

            DateTime birthDate = ReadDate(
                "Birth date (dd/MM/yyyy): ");

            Console.WriteLine("\nIs the lecturer suspended?");
            bool suspended = ReadYesNo();

            Lecturer lecturer = new Lecturer(
                firstName, lastName, id,
                birthDate, suspended);

            bool validCourses = false;

            while (!validCourses)
            {
                Console.WriteLine("\nAvailable courses:");

                List<Course> courses = courseManager.GetAllCourses();

                if (courses.Count == 0)
                {
                    Console.WriteLine("There are no courses in the system.");
                    return;
                }

                foreach (Course course in courses)
                {
                    Console.WriteLine(course.CourseCode + " - " +
                                      course.CourseName);
                }

                Console.WriteLine(
                    "\nEnter course codes separated by commas:");

                string input = Console.ReadLine() ?? "";

                string[] codes = input.Split(',');

                foreach (string code in codes)
                {
                    Course course = courseManager.FindCourse(code.Trim());

                    if (course != null)
                    {
                        lecturer.AddCourse(course);
                    }
                    else
                    {
                        Console.WriteLine(
                            "Course not found: " + code.Trim());
                    }
                }

                if (lecturer.Courses.Count > 0)
                {
                    validCourses = true;
                }
                else
                {
                    Console.WriteLine(
                        "The lecturer must have at least one valid course.");
                }
            }

            if (lecturerManager.AddLecturer(lecturer))
            {
                Console.WriteLine("Lecturer added successfully!");
            }
            else
            {
                Console.WriteLine("A lecturer with this ID already exists!");
            }
        }

        // =========================
        // OPEN COURSE OFFERING
        // =========================

        static void OpenCourseOffering()
        {
            Console.WriteLine("\n--- Open New Course Offering ---");

            // Step 1: Find course

            string code = ReadText("Enter course code: ");

            Course course = courseManager.FindCourse(code);

            if (course == null)
            {
                Console.WriteLine("Course not found!");
                return;
            }

            Console.WriteLine("\nSelected course: " + course.CourseName);

            // Step 2: Find lecturers

            List<Lecturer> lecturers =
                lecturerManager.GetLecturersForCourse(course);

            if (lecturers.Count == 0)
            {
                Console.WriteLine(
                    "No available lecturers can teach this course.");
                return;
            }

            Console.WriteLine("\nAvailable lecturers:");

            for (int i = 0; i < lecturers.Count; i++)
            {
                Console.WriteLine(
                    (i + 1) + ". " + lecturers[i]);
            }

            int lecturerChoice = ReadInt(
                "Choose lecturer: ", 1, lecturers.Count);

            Lecturer selectedLecturer =
                lecturers[lecturerChoice - 1];

            // Step 3: Get course dates and times

            DateTime startDate = ReadFutureDate(
                "Enter start date (dd/MM/yyyy): ");

            int meetings = ReadInt(
                "Number of meetings: ", 1, 1000);

            TimeSpan startTime = ReadTime(
                "Start time (HH:mm): ");

            TimeSpan endTime = ReadTime(
                "End time (HH:mm): ");

            while (endTime <= startTime)
            {
                Console.WriteLine(
                    "End time must be later than start time!");

                endTime = ReadTime(
                    "Enter end time again (HH:mm): ");
            }

            // Step 4: Calculate end date

            DateTime endDate =
                startDate.AddDays((meetings - 1) * 7);

            Console.WriteLine("\n--- Course Offering Details ---");

            Console.WriteLine("Course: " + course.CourseName);

            Console.WriteLine("Lecturer: " +
                              selectedLecturer.FirstName + " " +
                              selectedLecturer.LastName);

            Console.WriteLine("Start date: " +
                              startDate.ToShortDateString());

            Console.WriteLine("End date: " +
                              endDate.ToShortDateString());

            Console.WriteLine("Number of meetings: " + meetings);

            Console.WriteLine("Start time: " +
                              startTime.ToString(@"hh\:mm"));

            Console.WriteLine("End time: " +
                              endTime.ToString(@"hh\:mm"));

            Console.WriteLine("\nDo you approve these details?");

            bool approved = ReadYesNo();

            if (!approved)
            {
                Console.WriteLine("Course offering cancelled.");
                return;
            }

            // Step 5: Check lecturer availability

            bool lecturerAvailable =
                offeringManager.IsLecturerAvailable(
                    selectedLecturer,
                    startDate,
                    meetings,
                    startTime,
                    endTime);

            if (!lecturerAvailable)
            {
                Console.WriteLine(
                    "The lecturer is already scheduled for another course.");
                return;
            }

            // Step 6: Find available classrooms

            List<Classroom> availableClassrooms =
                offeringManager.GetAvailableClassrooms(
                    classroomManager.GetAllClassrooms(),
                    selectedLecturer,
                    startDate,
                    meetings,
                    startTime,
                    endTime);

            if (availableClassrooms.Count == 0)
            {
                Console.WriteLine(
                    "There are no available classrooms for this course.");
                return;
            }

            Console.WriteLine("\nAvailable classrooms:");

            for (int i = 0; i < availableClassrooms.Count; i++)
            {
                Console.WriteLine(
                    (i + 1) + ". " + availableClassrooms[i]);
            }

            // Step 7: Choose classroom

            int classroomChoice = ReadInt(
                "Choose classroom: ",
                1, availableClassrooms.Count);

            Classroom selectedClassroom =
                availableClassrooms[classroomChoice - 1];

            // Step 8: Create and save offering

            CourseOffering offering = new CourseOffering(
                course,
                selectedLecturer,
                selectedClassroom,
                startDate,
                meetings,
                startTime,
                endTime);

            if (offeringManager.AddOffering(offering))
            {
                Console.WriteLine(
                    "\nCourse offering opened successfully!");

                Console.WriteLine(offering);
            }
            else
            {
                Console.WriteLine(
                    "Could not open course offering. " +
                    "A scheduling conflict was found.");
            }
        }

        // =========================
        // SHOW OFFERINGS
        // =========================

        static void ShowOfferings()
        {
            Console.WriteLine("\n--- All Course Offerings ---");

            List<CourseOffering> offerings =
                offeringManager.GetAllOfferings();

            if (offerings.Count == 0)
            {
                Console.WriteLine("No course offerings found.");
                return;
            }

            foreach (CourseOffering offering in offerings)
            {
                Console.WriteLine(offering);
            }
        }

        // =========================
        // INPUT VALIDATION
        // =========================

        static string ReadText(string message)
        {
            Console.Write(message);

            string input = Console.ReadLine() ?? "";

            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty!");
                Console.Write(message);

                input = Console.ReadLine() ?? "";
            }

            return input.Trim();
        }

        static int ReadInt(string message, int min, int max)
        {
            Console.Write(message);

            int number;

            while (!int.TryParse(Console.ReadLine(), out number) ||
                   number < min || number > max)
            {
                Console.WriteLine(
                    "Please enter a number between " +
                    min + " and " + max);

                Console.Write(message);
            }

            return number;
        }

        static DateTime ReadDate(string message)
        {
            Console.Write(message);

            DateTime date;

            while (!DateTime.TryParse(
                       Console.ReadLine(), out date) ||
                   date.Date > DateTime.Today)
            {
                Console.WriteLine("Invalid birth date!");
                Console.Write(message);
            }

            return date;
        }

        static DateTime ReadFutureDate(string message)
        {
            Console.Write(message);

            DateTime date;

            while (!DateTime.TryParse(
                       Console.ReadLine(), out date) ||
                   date.Date < DateTime.Today)
            {
                Console.WriteLine(
                    "The course start date cannot be in the past!");

                Console.Write(message);
            }

            return date;
        }

        static TimeSpan ReadTime(string message)
        {
            Console.Write(message);

            TimeSpan time;

            while (!TimeSpan.TryParse(Console.ReadLine(), out time) ||
                   time < TimeSpan.Zero ||
                   time >= TimeSpan.FromDays(1))
            {
                Console.WriteLine("Invalid time!");
                Console.Write(message);
            }

            return time;
        }

        static bool ReadYesNo()
        {
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");

            int choice = ReadInt("Choice: ", 1, 2);

            return choice == 1;
        }
    }
}