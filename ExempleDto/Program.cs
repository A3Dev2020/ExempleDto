using System;
using System.Linq;
using System.Reflection;

namespace ExempleDto
{
    class Program
    {
        static void Main(string[] args)
        {
            Account a = new Account
            {
                Id = Guid.NewGuid(),
                Name = "Nicolas",
                Description = "Prof de C#",
                Password = "Electro-Encéphalograme"
            };
            
            AccountDto dto = new AccountDto();

            // C'est chiant à la main
            /*AccountDto dto = new AccountDto
            {
                Description = a.Description,
                Name = a.Name
            };*/

            MakeDto(a, dto);


        }

        public static void MakeDto(object src, object dst)
        {
            FieldInfo[] dtoFields = dst.GetType().GetFields();

            foreach (FieldInfo field in src.GetType().GetFields())
            {
                FieldInfo f = dtoFields.FirstOrDefault(i => i.Name == field.Name);

                if (f != null)
                {
                    f.SetValue(dst, field.GetValue(src));
                    Console.WriteLine(f.Name);
                }
            }
        }
    }
}
