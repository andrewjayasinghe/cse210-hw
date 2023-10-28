using System;


namespace assignment_demo
{
    public class MathAssignment : Assignment
    {
        protected string _textbookSection ="";
        protected string _problems ="";

        public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
        {
            _textbookSection = textbookSection;
            _problems = problems;
        } 

        public string GetHomeworkList()
        {
            return $"{_studentName} - {_topic} \nSection {_textbookSection} Problems {_problems}";
        }
    }
     
}