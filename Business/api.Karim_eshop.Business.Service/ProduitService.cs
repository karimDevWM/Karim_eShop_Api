//using api.Karim_eshop.Business.DTOs;
//using api.Karim_eshop.Business.Service.Contract;
//using api.Karim_eshop.Data.Entity.Model;
//using api.Karim_eshop.Data.Repository.Contract;
//using AutoMapper;
//using Microsoft.AspNetCore.JsonPatch;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace api.Karim_eshop.Business.Service
//{
//    public class ProduitService : IProduitService
//    {
//        private readonly IProduitRepository _produitRepository;
//        private readonly IMapper _mapper;

//        public ProduitService(IProduitRepository produitRepository, IMapper mapper)
//        {
//            _produitRepository = produitRepository;
//            _mapper = mapper;
//        }

//        public async Task<ProduitDto> CreateProductDTOAsync(ProduitDto productDTO)
//        {
//            var productToAdd = _mapper.Map<Produit>(productDTO);
//            var productAdded = await _produitRepository.CreateProductAsync(productToAdd).ConfigureAwait(false);

//            return _mapper.Map<ProduitDto>(productAdded);
//        }

//        public async Task <List<ProduitDto>> GetProductsAsync()
//        {
//            var products = await _produitRepository.GetAllProductsAsync().ConfigureAwait(false);

//            List<ProduitDto> produitListDto = new(products.Count);

//            foreach (var product in products)
//            {
//                produitListDto.Add(_mapper.Map<ProduitDto>(product));
//            }

//            return produitListDto;
//        }

//        public async Task<ProduitDto> GetProductByIdAsync(int produitId)
//        {
//            var product = await _produitRepository.GetProductByIdAsync(produitId).ConfigureAwait(false);

//            return _mapper.Map<ProduitDto>(product);
//        }

//        public async Task<ProduitDto> UpdateProductAsync(ProduitDto produitDto, int produitId)
//        {
//            var productGet = await _produitRepository.GetProductByIdAsync(produitId).ConfigureAwait(false);

//            productGet.ProduitLibelle = produitDto.ProduitLibelle;
//            productGet.ProduitDescription = produitDto.ProduitDescription;
//            productGet.ProduitImage = produitDto.ProduitImage;
//            productGet.ProduitPrix = produitDto.ProduitPrix;

//            var produitUpdated = await _produitRepository.UpdateProductAsync(productGet).ConfigureAwait(false);

//            return _mapper.Map<ProduitDto>(produitUpdated);
//        }
//    }
//}
