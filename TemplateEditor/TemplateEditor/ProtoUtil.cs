/**
 * 
 * Proto serialize and deserialize class
 * 
 * @author lazy
 *
 */
using System;
using System.IO;
using System.Text;
using ProtoBuf;
using System.Reflection;

namespace TemplateEditor
{
    public class ProtoUtil 
	{

		public static T Deserialize<T>(byte[] buffer) 
		{
			using (var stream = new MemoryStream(buffer)) 
			{
				return (T)Serializer.Deserialize<T>(stream);
			} 
		}

		public static T Deserialize<T>(ByteBuffer buffer)
		{
			byte[] data = buffer.ReadBytes ();

			return (T)Deserialize<T> (data);
		}

		public static byte[] Serialize<T>(T obj) 
		{
            using (var stream = new MemoryStream()) 
			{
                Serializer.Serialize(stream, obj);
                stream.Flush();
                return stream.ToArray();
            }
        }

		public static byte[] Serialize(ProtoBuf.IExtensible proto)
		{
			using (var stream = new MemoryStream()) 
			{
				Serializer.Serialize(stream, proto);
				stream.Flush();
				return stream.ToArray();
			}
		}

    }
}
