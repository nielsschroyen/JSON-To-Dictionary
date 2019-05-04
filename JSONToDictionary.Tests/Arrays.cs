using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace JSONToDictionary.Tests
{
    [TestFixture]
    public class Arrays
    {
        [Test]
        public void ArrayWithStrings()
        {
            var json = "{'persons':['Jon','Arya']}";
            var dictionary = JSONToDictionary.ToDictionary(json);

            IList<string> persons = dictionary.GetList<string>("persons");
            Assert.That(persons[0], Is.EqualTo("Jon"));
            Assert.That(persons[1], Is.EqualTo("Arya"));
        }

        [Test]
        public void ArrayWithObjects()
        {
            var json = "{'persons':[{name:'Jon'},{name:'Arya'}]}";
            var dictionary = JSONToDictionary.ToDictionary(json);

            var persons = dictionary.GetListWithObjects("persons");
            Assert.That(persons[0]["name"], Is.EqualTo("Jon"));
            Assert.That(persons[1]["name"], Is.EqualTo("Arya"));
        }

        [Test]
        public void ArrayOfArrays()
        {
            var json = "{'persons':[['Jon','Arya'],['Daenerys','Cersei']]}";
            var dictionary = JSONToDictionary.ToDictionary(json);

            var persons = dictionary.GetList<IList>("persons");

            Assert.That(persons[0][0], Is.EqualTo("Jon"));
            Assert.That(persons[0][1], Is.EqualTo("Arya"));
            Assert.That(persons[1][0], Is.EqualTo("Daenerys"));
            Assert.That(persons[1][1], Is.EqualTo("Cersei"));
        }
    }
}