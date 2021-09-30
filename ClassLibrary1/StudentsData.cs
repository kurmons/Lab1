using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassLibrary1
{
    public class StudentsData
    {
        /// <summary>
        /// Studentu saraksts.
        /// </summary>
        public List<Student> Students { get; private set; }

        /// <summary>
        /// Studentu saraksts.
        /// </summary>
        public const string DefaultFilename = @"..\..\..\students.xml";

        /// <summary>
        /// Studentu saraksta inicializēšana.
        /// </summary>
        public StudentsData()
        {
            this.Students = new List<Student>();
        }

        /// <summary>
        /// Pievieno sarakstam jaunu studentu.
        /// </summary>
        public void Add(Student newStud)
        {
            if (newStud != null)
                this.Students.Add(newStud); // studenta objekta pievienošana
        }

        /// <summary>
        /// Saglabā XML formāta failā tekošo studentu sarakstu.
        /// </summary>
        public void Save(string filename)
        {
            if (filename.Length == 0)
                filename = DefaultFilename;

            FileStream data = new FileStream(filename, FileMode.Create, FileAccess.Write);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new Type[] { typeof(Student) });

            serializer.Serialize(data, this.Students);
            data.Close();
        }

        /// <summary>
        /// Saglabā XML formāta faila studentu sarakstu.
        /// </summary>
        public void Load(string filename)
        {
            if (filename.Length == 0)
                filename = DefaultFilename;

            FileStream data = new FileStream(filename, FileMode.Open, FileAccess.Read);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new Type[] { typeof(Student) });

            this.Students.AddRange((List<Student>)serializer.Deserialize(data));
            data.Close();
        }
    }
}
