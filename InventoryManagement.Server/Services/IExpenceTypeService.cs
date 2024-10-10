﻿using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public interface IExpenceTypeService
    {


        public List<ExpenceTypesDTO> GetAllExpenceTypes();
        public ExpenceTypesDTO GetExpenceTypesById(int id);
        public ExpenceTypesDTO CreateExpenceTypes(ExpenceTypesDTO ExpenceTypesDto);
        public ExpenceTypesDTO UpdateExpenceTypes(int id, ExpenceTypesDTO ExpenceTypesDto);
        public void DeleteExpenceTypes(int id);
    }
}
