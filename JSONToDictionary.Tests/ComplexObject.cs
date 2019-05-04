using NUnit.Framework;

namespace JSONToDictionary.Tests
{
    [TestFixture]
    public class ComplexObject
    {
        [Test]
        public void TwoLevels()
        {
            var json = @"{person:{
                            name:'Jon',
                            age:33,
                            length:178.5,
                            married:true
                          }
                       }";
            var dictionary = JSONToDictionary.ToDictionary(json);

            Assert.That(dictionary.GetDictionary("person")["name"], Is.EqualTo("Jon"));
            Assert.That(dictionary.GetDictionary("person")["age"], Is.EqualTo(33));
            Assert.That(dictionary.GetDictionary("person")["length"], Is.EqualTo(178.5));
            Assert.That(dictionary.GetDictionary("person")["married"], Is.EqualTo(true));
        }


        [Test]
        public void ThreeLevels()
        {
            var json = @"{person:{
                            name:'Jon',
                            address:{
                                street:'Fifth avenue',
                                city:'New York'
                            }
                          }
                       }";
            var dictionary = JSONToDictionary.ToDictionary(json);

            Assert.That(dictionary.GetDictionary("person").GetDictionary("address")["street"], Is.EqualTo("Fifth avenue"));
            Assert.That(dictionary.GetDictionary("person").GetDictionary("address")["city"], Is.EqualTo("New York"));
        }

        [Test]
        public void Person()
        {
            var json = @"{person:{
                            name:'Jon',
                            age:33,
                            length:178.5,
                            married:true,
                            address:{
                                street:'Fifth avenue',
                                city:'New York'
                            }
                          }
                       }";
            var dictionary = JSONToDictionary.ToDictionary(json);

            Assert.That(dictionary.GetDictionary("person")["name"], Is.EqualTo("Jon"));
            Assert.That(dictionary.GetDictionary("person")["age"], Is.EqualTo(33));
            Assert.That(dictionary.GetDictionary("person")["length"], Is.EqualTo(178.5));
            Assert.That(dictionary.GetDictionary("person")["married"], Is.EqualTo(true));
            Assert.That(dictionary.GetDictionary("person").GetDictionary("address")["street"], Is.EqualTo("Fifth avenue"));
            Assert.That(dictionary.GetDictionary("person").GetDictionary("address")["city"], Is.EqualTo("New York"));
        }
    }
}