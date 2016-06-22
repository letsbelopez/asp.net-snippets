using Sabio.Data;
using Sabio.Web.Domain;
using Sabio.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sabio.Web.Services
{
    public class LanguageService : BaseService, ILanguageService
    {
        public int Insert(LanguageAddRequest model)
        {
            int id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Languages_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@UserId", UserService.GetCurrentUserId());
                   paramCollection.AddWithValue("@LanguageName", model.LanguageName);
                   paramCollection.AddWithValue("@LanguageAbbreviation", model.LanguageAbbreviation);
                   paramCollection.AddWithValue("@DisplayOrder", model.DisplayOrder);

                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                   p.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(p);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out id);
               }
               );


            return id;
        }

        public void Update(LanguageUpdateRequest model)
        {           
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Languages_Update"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {                  
                   paramCollection.AddWithValue("@LanguageName", model.LanguageName);
                   paramCollection.AddWithValue("@LanguageAbbreviation", model.LanguageAbbreviation);
                   paramCollection.AddWithValue("@DisplayOrder", model.DisplayOrder);
                   paramCollection.AddWithValue("@Id", model.Id);              
               }
               );                        
        }

        public Language GetOne(int id)
        {
            Language c = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Languages_SelectById"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                },
                map: delegate (IDataReader reader, short set)
                {
                    c = new Language();
                    int colpos = 0;
                    c.Id = reader.GetSafeInt32(colpos++);
                    c.LanguageName = reader.GetSafeString(colpos++);
                    c.LanguageAbbreviation = reader.GetSafeString(colpos++);
                    c.DisplayOrder = reader.GetSafeInt32(colpos++);
                }                             
                );

            return c;
        }
        
        public List<Language> GetLanguages()
        {
            List<Language> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Languages_SelectAll"
                , inputParamMapper: null
                ,map: delegate (IDataReader reader, short set)
                {
                    Language l = new Language();
                    int colpos = 0;                    
                    l.LanguageName = reader.GetSafeString(colpos++);
                    l.LanguageAbbreviation = reader.GetSafeString(colpos++);
                    l.DisplayOrder = reader.GetSafeInt32(colpos++);
                    l.Id = reader.GetSafeInt32(colpos++);

                    if (list == null)
                    {
                        list = new List<Language>();
                    }

                    list.Add(l);
                }
                );

            return list;
        }

        public void Delete(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Languages_Delete"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {                   
                   paramCollection.AddWithValue("@Id", id);
               }
               );
        }
    }
}
