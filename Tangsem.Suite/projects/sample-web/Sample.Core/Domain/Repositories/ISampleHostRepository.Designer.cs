using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Data.Domain;

using Sample.Core.Domain.Entities;

namespace Sample.Core.Domain.Repositories
{
	/// <summary>
	/// The ISampleHostRepository interface.
	/// </summary>
	public partial interface ISampleHostRepository : IRepository
	{

		
		/// <summary>
		/// Maps to database table/view Form. The IQueryable for Forms.
		/// </summary>
		IQueryable<Form> Forms { get; }

		
		
		/// <summary>
		/// Maps to database table/view FormSigner. The IQueryable for FormSigners.
		/// </summary>
		IQueryable<FormSigner> FormSigners { get; }

		
		
		/// <summary>
		/// Maps to database table/view Signer. The IQueryable for Signers.
		/// </summary>
		IQueryable<Signer> Signers { get; }

		
		
		/// <summary>
		/// Maps to database table/view ShopeeItemPullHistory. The IQueryable for ShopeeItemPullHistories.
		/// </summary>
		IQueryable<ShopeeItemPullHistory> ShopeeItemPullHistories { get; }

		
		
		/// <summary>
		/// Maps to database table/view ShopeeShopUser. The IQueryable for ShopeeShopUsers.
		/// </summary>
		IQueryable<ShopeeShopUser> ShopeeShopUsers { get; }

		
		
		/// <summary>
		/// Maps to database table/view ShopeeShop. The IQueryable for ShopeeShops.
		/// </summary>
		IQueryable<ShopeeShop> ShopeeShops { get; }

				
		

		
		/// <summary>
		/// Get Form by primary key.
		/// </summary>
		Form LookupFormById(int id);
		
		/// <summary>
		/// Delete Form by primary key.
		/// </summary>
		Form DeleteFormById(int id);
		
		/// <summary>
		/// Save a new Form instance.
		/// </summary>
		Form SaveForm(Form form);
		
		/// <summary>
		/// Update an existing Form instance.
		/// </summary>
		Form UpdateForm(Form form);
		
		/// <summary>
		/// Save or update an existing Form instance.
		/// </summary>
		Form SaveOrUpdateForm(Form form);

		
		
		/// <summary>
		/// Get FormSigner by primary key.
		/// </summary>
		FormSigner LookupFormSignerById(int id);
		
		/// <summary>
		/// Delete FormSigner by primary key.
		/// </summary>
		FormSigner DeleteFormSignerById(int id);
		
		/// <summary>
		/// Save a new FormSigner instance.
		/// </summary>
		FormSigner SaveFormSigner(FormSigner formSigner);
		
		/// <summary>
		/// Update an existing FormSigner instance.
		/// </summary>
		FormSigner UpdateFormSigner(FormSigner formSigner);
		
		/// <summary>
		/// Save or update an existing FormSigner instance.
		/// </summary>
		FormSigner SaveOrUpdateFormSigner(FormSigner formSigner);

		
		
		/// <summary>
		/// Get Signer by primary key.
		/// </summary>
		Signer LookupSignerById(int id);
		
		/// <summary>
		/// Delete Signer by primary key.
		/// </summary>
		Signer DeleteSignerById(int id);
		
		/// <summary>
		/// Save a new Signer instance.
		/// </summary>
		Signer SaveSigner(Signer signer);
		
		/// <summary>
		/// Update an existing Signer instance.
		/// </summary>
		Signer UpdateSigner(Signer signer);
		
		/// <summary>
		/// Save or update an existing Signer instance.
		/// </summary>
		Signer SaveOrUpdateSigner(Signer signer);

		
		
		/// <summary>
		/// Get ShopeeItemPullHistory by primary key.
		/// </summary>
		ShopeeItemPullHistory LookupShopeeItemPullHistoryById(int id);
		
		/// <summary>
		/// Delete ShopeeItemPullHistory by primary key.
		/// </summary>
		ShopeeItemPullHistory DeleteShopeeItemPullHistoryById(int id);
		
		/// <summary>
		/// Save a new ShopeeItemPullHistory instance.
		/// </summary>
		ShopeeItemPullHistory SaveShopeeItemPullHistory(ShopeeItemPullHistory shopeeItemPullHistory);
		
		/// <summary>
		/// Update an existing ShopeeItemPullHistory instance.
		/// </summary>
		ShopeeItemPullHistory UpdateShopeeItemPullHistory(ShopeeItemPullHistory shopeeItemPullHistory);
		
		/// <summary>
		/// Save or update an existing ShopeeItemPullHistory instance.
		/// </summary>
		ShopeeItemPullHistory SaveOrUpdateShopeeItemPullHistory(ShopeeItemPullHistory shopeeItemPullHistory);

		
		
		/// <summary>
		/// Get ShopeeShopUser by primary key.
		/// </summary>
		ShopeeShopUser LookupShopeeShopUserById(int id);
		
		/// <summary>
		/// Delete ShopeeShopUser by primary key.
		/// </summary>
		ShopeeShopUser DeleteShopeeShopUserById(int id);
		
		/// <summary>
		/// Save a new ShopeeShopUser instance.
		/// </summary>
		ShopeeShopUser SaveShopeeShopUser(ShopeeShopUser shopeeShopUser);
		
		/// <summary>
		/// Update an existing ShopeeShopUser instance.
		/// </summary>
		ShopeeShopUser UpdateShopeeShopUser(ShopeeShopUser shopeeShopUser);
		
		/// <summary>
		/// Save or update an existing ShopeeShopUser instance.
		/// </summary>
		ShopeeShopUser SaveOrUpdateShopeeShopUser(ShopeeShopUser shopeeShopUser);

		
		
		/// <summary>
		/// Get ShopeeShop by primary key.
		/// </summary>
		ShopeeShop LookupShopeeShopById(int id);
		
		/// <summary>
		/// Delete ShopeeShop by primary key.
		/// </summary>
		ShopeeShop DeleteShopeeShopById(int id);
		
		/// <summary>
		/// Save a new ShopeeShop instance.
		/// </summary>
		ShopeeShop SaveShopeeShop(ShopeeShop shopeeShop);
		
		/// <summary>
		/// Update an existing ShopeeShop instance.
		/// </summary>
		ShopeeShop UpdateShopeeShop(ShopeeShop shopeeShop);
		
		/// <summary>
		/// Save or update an existing ShopeeShop instance.
		/// </summary>
		ShopeeShop SaveOrUpdateShopeeShop(ShopeeShop shopeeShop);

		
	}
}