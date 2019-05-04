using NUnit.Framework;

namespace JSONToDictionary.Tests
{
    public class ConvertToObject
    {
        [Test]
        public void CustomObject()
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

            Assert.That(dictionary.GetDictionary("person").GetObject<Address>("address").city, Is.EqualTo("New York"));
            Assert.That(dictionary.GetDictionary("person").GetObject<Address>("address").street, Is.EqualTo("Fifth avenue"));
        }

        [Test]
        public void ListWithObjects()
        {
            var json = @"{person:{
                            name:'Jon',
                            addresses:[{
                                street:'Fifth avenue',
                                city:'New York'
                            },
                               {
                                street:'Third avenue',
                                city:'Washington'
                            }]
                          }
                       }";
            var dictionary = JSONToDictionary.ToDictionary(json);

            var addresses = dictionary.GetDictionary("person").GetListWithTypedObjects<Address>("addresses");
            Assert.That(addresses[0].city, Is.EqualTo("New York"));
            Assert.That(addresses[1].city, Is.EqualTo("Washington"));
        }


        public class Address
        {
            public string street { get; set; }
            public string city { get; set; }
        }
    }
}