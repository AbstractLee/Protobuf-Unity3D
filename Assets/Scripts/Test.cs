using ProtoBuf;
using System.IO;
using UnityEngine;

[ProtoContract]
class Person
{
    private int _id;
    private string _name;
    [ProtoMember(1)]
    public int Id
    {
        get
        {
            return _id;
        }

        set
        {
            _id = value;
        }
    }
    [ProtoMember(2)]
    public string Name
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }
}

public class Test : MonoBehaviour {


	// Use this for initialization
	void Start () {

        Person p = new Person
        {
            Id = 1,
            Name = "Flylee"
        };

        //序列化到文件
        using (Stream s = File.OpenWrite("Assets/Data/data.bytes"))
        {
            Serializer.Serialize<Person>(s, p);
        }

        //读取文件并反序列化
        using (Stream s = File.OpenRead("Assets/Data/data.bytes"))
        {
            Person pTemp = null;
            pTemp = Serializer.Deserialize<Person>(s);
            Debug.Log(p.Id + pTemp.Name);
        }     

	}
	

}
