using System;


namespace assignment_demo
{
    public class WritingAssignment : Assignment
    {
        protected string _title ="";
        
        public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
        {
            _title = title;
        }

        public string GetWritingInfromation()
        {
            return $"{_studentName} - {_topic} \n{_title} by {_studentName}";       
        }
    }
     
}