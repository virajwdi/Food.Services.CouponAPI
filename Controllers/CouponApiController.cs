using AutoMapper;
using Food.Services.CouponAPI.Data;
using Food.Services.CouponAPI.Models;
using Food.Services.CouponAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Food.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ResponseDto _response;
        private IMapper _mapper;
        public CouponApiController(AppDbContext db, IMapper mapper)
        {
            _db = db; 
            _mapper= mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                 _response.Result = _mapper.Map<CouponDto>(objList);
            }
            catch (Exception ex) {
                _response.IsSuccess=false;
                _response.Message=ex.Message;
            }
            return _response;

        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try {
                Coupon objList = _db.Coupons.First(u => u.CouponId == id);
                _response.Result = _mapper.Map<CouponDto>(objList);
            } catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;     
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{codeId}")]
        public ResponseDto GetByCode(string code)
        {
            try {
                Coupon objList = _db.Coupons.First(u => u.CouponCode.ToLower() == code.ToLower());
                _response.Result = objList;
            } catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Route("AddCoupon")]
        public ResponseDto Post([FromBody] CouponDto couponDto) {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);
                 
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message; 
            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);
            }catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(u => u.CouponId == id);
                _db.Coupons.Remove(obj);    
                _db.SaveChanges();

            }catch(Exception ex) { 
                _response.IsSuccess=false;
                _response.Message = ex.Message;
            }
            return _response;
        }

    }
}
