using RCA.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using RCA.DTO.DTO;
using RCA.Interface.Result;
using RCA.Data.Models;
using System.Linq;
using AutoMapper;

namespace RCA.Service.Services
{
    public class CafeService : ICafeService
    {
        public Result<CafeDTO> GetByExternalCode(string externalCode)
        {
            Result<CafeDTO> result;
            try
            {
                using (RCADataContext context = new RCADataContext())
                {
                    Cafe cafe = context.Cafe.Where(w => w.AppSecret == externalCode).FirstOrDefault();
                    CafeDTO cafeDTO = Mapper.Map<Cafe, CafeDTO>(cafe);
                    result = new Result<CafeDTO>(cafeDTO);
                }
            }
            catch (Exception ex)
            {
                result = new Result<CafeDTO>(false,ResultType.Error,$"CafeService.GetByExternalCode Method Ex: {ex.ToString()}");
            }
            return result;
        }

        public Result<CafeDTO> GetByID(int id)
        {
            Result<CafeDTO> result;
            CafeDTO cafeDTO;
            try
            {
                using (RCADataContext context = new RCADataContext())
                {
                    cafeDTO = Mapper.Map<Cafe,CafeDTO>(context.Cafe.Where(w => w.Id == id).FirstOrDefault());
                    result = new Result<CafeDTO>(cafeDTO);
                }
            }
            catch (Exception ex)
            {
                result = new Result<CafeDTO>(false,ResultType.Error,$"CafeService.GetByID Method Ex: {ex.ToString()}");
            }
            return result;
        }

        public Result<CafeDTO> GetByName(string name)
        {
            Result<CafeDTO> result;
            CafeDTO cafeDTO;
            try
            {
                using (RCADataContext context = new RCADataContext())
                {
                    cafeDTO = Mapper.Map<Cafe, CafeDTO>(context.Cafe.Where(w => w.Name == name).FirstOrDefault());
                    result = new Result<CafeDTO>(cafeDTO);
                }
            }
            catch (Exception ex)
            {
                result = new Result<CafeDTO>(false, ResultType.Error, $"CafeService.GetByName Method Ex: {ex.ToString()}");
            }
            return result;
        }

        public Result<CafeDTO> GetByOwnerId(string ownerId)
        {
            Result<CafeDTO> result;
            CafeDTO cafeDTO;
            try
            {
                using (RCADataContext context = new RCADataContext())
                {
                    cafeDTO = Mapper.Map<Cafe, CafeDTO>(context.Cafe.Where(w => w.OwnerId == ownerId).FirstOrDefault());
                    result = new Result<CafeDTO>(cafeDTO);
                }
            }
            catch (Exception ex)
            {
                result = new Result<CafeDTO>(false, ResultType.Error, $"CafeService.GetByOwnerID Method Ex: {ex.ToString()}");
            }
            return result;
        }
    }
}
