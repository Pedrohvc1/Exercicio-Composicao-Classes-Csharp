using ExComposicao.Entities.Enums;
using System.Collections.Generic;

namespace ExComposicao.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; } // associa o obj Worker com o Department (composicao de obj)
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); // foi criado uma lista pois o worker tem varios contratos.


        public Worker()
        {
        }

        //Em via de regra não é add uma lista vazia no construtor
        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract) // add na lista de contratos o contrato passado
        {
            Contracts.Add(contract);
        }
        public void Removecontract(HourContract contract) //remove da lista de contratos o contrato passado
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month) // quanto que o func ganhou
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts) // para cada HourContract na minha lista de contratos
            {
                //se o ano do meu contrato for igual ao ano que eu recebi como argumento 
                //e tbm o mes do contrato for igual ao mes que eu recebi do argumento.
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue(); // operação que retorna o valor do contrato
                }
            }
            return sum;
        }
    }
}
