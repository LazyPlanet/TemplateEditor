#include <map>
#include <string>
#include <vector>
#include <functional>
#include <numeric>

#include <string>

#include <google/protobuf/stubs/common.h>

#include <google/protobuf/generated_message_util.h>
#include <google/protobuf/message.h>
#include <google/protobuf/repeated_field.h>
#include <google/protobuf/extension_set.h>
#include <google/protobuf/generated_enum_reflection.h>
#include <google/protobuf/unknown_field_set.h>
// @@protoc_insertion_point(includes)

class TemplateManager
{
public:

	static std::map<int, std::map<int, ::google::protobuf::Message*> > m_Tempaltes;
        
    TemplateManager() { }

	static bool Load();

	static std::map<int, ::google::protobuf::Message*>* GetTemplates(int type);	
	
	::google::protobuf::Message* Get(int, int tid); 

	//template<class T>
	static int Random(::google::protobuf::RepeatedPtrField<int>& choices)
	{
		int sum = std::accumulate(choices.begin(), choices.end(), 0);

		int rnd = rand();

		for (int it = 0; it != choices.size(); ++it)
		{
			if (rnd < choices.Get(it))
			{
				return it;
			}
			
			rnd -= choices.Get(it);
		}

		return -1;
	}

	static const int TemplateManager::RandomWithWeight(const std::vector<int>& choices)
	{
		int sum = std::accumulate(choices.begin(), choices.end(), 0);    

		if (sum <= 0) return -1; 

		int rnd = rand() % sum;    

		for (size_t index = 0; index < choices.size(); ++index)    
		{    
			if (rnd < choices[index])    
			{    
				return index;    
			}   

			rnd -= choices[index];    
		}    

		return -1; 
	}
};
