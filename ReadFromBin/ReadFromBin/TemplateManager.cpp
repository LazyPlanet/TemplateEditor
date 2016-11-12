#include <map>
#include <string>
#include "ByteBuffer.h"
#include "TemplateManager.h"

std::map<int, std::map<int, google::protobuf::Message*> > TemplateManager::m_Tempaltes;

bool TemplateManager::Load()
{

	std::vector<int> choices;

	for (int i = 0; i < 10; i++)
	{
		//int rnd = rand() % 100;    
		choices.push_back(i);
	}
	
	std::map<int, int> results;

	for (int i = 0; i < 1000000; i++)
	{
		int rnt = RandomWithWeight(choices);
		results[rnt]++;
	}

	std::string root = "./";

	try
	{
		using namespace google::protobuf;

		std::string filename = "config_common.proto";

		const DescriptorPool* _pool = DescriptorPool::generated_pool();
		const FileDescriptor* _descriptor = _pool->FindFileByName(filename);

		for(int i = 0; i < _descriptor->message_type_count(); i ++)
		{
			const Descriptor* descriptor = _descriptor->message_type(i);

			const Message* msg = MessageFactory::generated_factory()->GetPrototype(descriptor);

			FILE* file = fopen((root + descriptor->name()).c_str(), "r"); 
			if (file == NULL) continue; 
				
			ByteBuffer buffer = ByteBuffer::CopyFromBytes(file); 

			std::map<int, ::google::protobuf::Message*> lists; 

			size_t buffer_length = buffer.wpos(); 
			//size_t length = buffer.ReadInt();
			//int length = buffer.read<int>();

			size_t rem_length = 0;
			//assert(length % size == 0);

			//or (size_t k = 0; k < length; ++k) 
			while(buffer.rpos() != buffer.wpos())
			{ 
				Message* message = msg->New();

				int size = buffer.ReadInt();
				//int size = buffer.read<int>();
				rem_length += size;
				std::string content = buffer.ReadString(size);
				((google::protobuf::MessageLite*)message)->ParseFromString(content); 

				const FieldDescriptor* field_index = message->GetDescriptor()->FindFieldByName("index");
				int index = message->GetReflection()->GetInt32((::google::protobuf::Message&)(*message), field_index);

				const FieldDescriptor* field_version = message->GetDescriptor()->FindFieldByName("version");
				const EnumValueDescriptor* enum_version = message->GetReflection()->GetEnum((::google::protobuf::Message&)(*message), field_version);

				message->GetReflection()->GetMessage(message, field_version);

				int version = enum_version->number();
				//assert(PB::Version_IsValid(version));

				//if (version != GetVersion() && version != PB::GLOBAL) continue; 

				lists.insert(std::make_pair(index, (::google::protobuf::Message*)message)); 
			}
			//buffer.clear();

			m_Tempaltes.insert(std::make_pair((int)descriptor->FindFieldByNumber(1)->default_value_enum()->number(), lists)); 

		}

	}
	catch (std::exception ex)
	{
		throw ex.what();
		return false;
	}

	return true;
}
        
std::map<int, ::google::protobuf::Message*>* TemplateManager::GetTemplates(int type)
{
	auto it = m_Tempaltes.find(type);
	
	if (it != m_Tempaltes.end())
	{
	    return &(it->second);
	}
	
	return NULL;
}

::google::protobuf::Message* TemplateManager::Get(int type, int tid)
{
	std::map<int, ::google::protobuf::Message*>* templates = GetTemplates(type);
	if (templates == NULL) return NULL;

	auto it = templates->find(tid);

	if (it != templates->end())
	{
		return it->second;
	}

	return NULL;
}
