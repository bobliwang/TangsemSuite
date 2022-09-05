using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Data.Domain;
using Tangsem.NHibernate.Domain;
using Sample.Core.Domain.Entities;

namespace Sample.Core.Domain.Repositories.NHibernate
{ 
  /// <summary>
  /// The SampleHostRepository class.
  /// </summary>
  public partial class SampleHostRepository : Tangsem.Identity.Domain.Repositories.NHibernate.IdentityRepository, ISampleHostRepository
  {

    
    /// <summary>
    /// The IQueryable for Forms.
    /// </summary>
    public virtual IQueryable<Form> Forms
    {
      get
      {
        return this.GetEntities<Form>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for FormSigners.
    /// </summary>
    public virtual IQueryable<FormSigner> FormSigners
    {
      get
      {
        return this.GetEntities<FormSigner>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for Signers.
    /// </summary>
    public virtual IQueryable<Signer> Signers
    {
      get
      {
        return this.GetEntities<Signer>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for ShopeeItemPullHistories.
    /// </summary>
    public virtual IQueryable<ShopeeItemPullHistory> ShopeeItemPullHistories
    {
      get
      {
        return this.GetEntities<ShopeeItemPullHistory>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for ShopeeShopUsers.
    /// </summary>
    public virtual IQueryable<ShopeeShopUser> ShopeeShopUsers
    {
      get
      {
        return this.GetEntities<ShopeeShopUser>();
      }
    }

    
    
    /// <summary>
    /// The IQueryable for ShopeeShops.
    /// </summary>
    public virtual IQueryable<ShopeeShop> ShopeeShops
    {
      get
      {
        return this.GetEntities<ShopeeShop>();
      }
    }

        
    

    
    /// <summary>
    /// Get Form by primary key.
    /// </summary>
    public virtual Form LookupFormById(int id)
    {
      return this.LookupById<Form>(id);
    }
    
    /// <summary>
    /// Delete Form by primary key.
    /// </summary>
    public virtual Form DeleteFormById(int id)
    {
      return this.DeleteById<Form>(id);
    }
    
    /// <summary>
    /// Save a new Form instance.
    /// </summary>
    public virtual Form SaveForm(Form form)
    {
      return this.Save<Form>(form);
    }
    
    /// <summary>
    /// Update an existing Form instance.
    /// </summary>
    public virtual Form UpdateForm(Form form)
    {
      return this.Update<Form>(form);
    }
    
    /// <summary>
    /// Save or update an existing Form instance.
    /// </summary>
    public virtual Form SaveOrUpdateForm(Form form)
    {
      return this.SaveOrUpdate<Form>(form);
    }

    
    
    /// <summary>
    /// Get FormSigner by primary key.
    /// </summary>
    public virtual FormSigner LookupFormSignerById(int id)
    {
      return this.LookupById<FormSigner>(id);
    }
    
    /// <summary>
    /// Delete FormSigner by primary key.
    /// </summary>
    public virtual FormSigner DeleteFormSignerById(int id)
    {
      return this.DeleteById<FormSigner>(id);
    }
    
    /// <summary>
    /// Save a new FormSigner instance.
    /// </summary>
    public virtual FormSigner SaveFormSigner(FormSigner formSigner)
    {
      return this.Save<FormSigner>(formSigner);
    }
    
    /// <summary>
    /// Update an existing FormSigner instance.
    /// </summary>
    public virtual FormSigner UpdateFormSigner(FormSigner formSigner)
    {
      return this.Update<FormSigner>(formSigner);
    }
    
    /// <summary>
    /// Save or update an existing FormSigner instance.
    /// </summary>
    public virtual FormSigner SaveOrUpdateFormSigner(FormSigner formSigner)
    {
      return this.SaveOrUpdate<FormSigner>(formSigner);
    }

    
    
    /// <summary>
    /// Get Signer by primary key.
    /// </summary>
    public virtual Signer LookupSignerById(int id)
    {
      return this.LookupById<Signer>(id);
    }
    
    /// <summary>
    /// Delete Signer by primary key.
    /// </summary>
    public virtual Signer DeleteSignerById(int id)
    {
      return this.DeleteById<Signer>(id);
    }
    
    /// <summary>
    /// Save a new Signer instance.
    /// </summary>
    public virtual Signer SaveSigner(Signer signer)
    {
      return this.Save<Signer>(signer);
    }
    
    /// <summary>
    /// Update an existing Signer instance.
    /// </summary>
    public virtual Signer UpdateSigner(Signer signer)
    {
      return this.Update<Signer>(signer);
    }
    
    /// <summary>
    /// Save or update an existing Signer instance.
    /// </summary>
    public virtual Signer SaveOrUpdateSigner(Signer signer)
    {
      return this.SaveOrUpdate<Signer>(signer);
    }

    
    
    /// <summary>
    /// Get ShopeeItemPullHistory by primary key.
    /// </summary>
    public virtual ShopeeItemPullHistory LookupShopeeItemPullHistoryById(int id)
    {
      return this.LookupById<ShopeeItemPullHistory>(id);
    }
    
    /// <summary>
    /// Delete ShopeeItemPullHistory by primary key.
    /// </summary>
    public virtual ShopeeItemPullHistory DeleteShopeeItemPullHistoryById(int id)
    {
      return this.DeleteById<ShopeeItemPullHistory>(id);
    }
    
    /// <summary>
    /// Save a new ShopeeItemPullHistory instance.
    /// </summary>
    public virtual ShopeeItemPullHistory SaveShopeeItemPullHistory(ShopeeItemPullHistory shopeeItemPullHistory)
    {
      return this.Save<ShopeeItemPullHistory>(shopeeItemPullHistory);
    }
    
    /// <summary>
    /// Update an existing ShopeeItemPullHistory instance.
    /// </summary>
    public virtual ShopeeItemPullHistory UpdateShopeeItemPullHistory(ShopeeItemPullHistory shopeeItemPullHistory)
    {
      return this.Update<ShopeeItemPullHistory>(shopeeItemPullHistory);
    }
    
    /// <summary>
    /// Save or update an existing ShopeeItemPullHistory instance.
    /// </summary>
    public virtual ShopeeItemPullHistory SaveOrUpdateShopeeItemPullHistory(ShopeeItemPullHistory shopeeItemPullHistory)
    {
      return this.SaveOrUpdate<ShopeeItemPullHistory>(shopeeItemPullHistory);
    }

    
    
    /// <summary>
    /// Get ShopeeShopUser by primary key.
    /// </summary>
    public virtual ShopeeShopUser LookupShopeeShopUserById(int id)
    {
      return this.LookupById<ShopeeShopUser>(id);
    }
    
    /// <summary>
    /// Delete ShopeeShopUser by primary key.
    /// </summary>
    public virtual ShopeeShopUser DeleteShopeeShopUserById(int id)
    {
      return this.DeleteById<ShopeeShopUser>(id);
    }
    
    /// <summary>
    /// Save a new ShopeeShopUser instance.
    /// </summary>
    public virtual ShopeeShopUser SaveShopeeShopUser(ShopeeShopUser shopeeShopUser)
    {
      return this.Save<ShopeeShopUser>(shopeeShopUser);
    }
    
    /// <summary>
    /// Update an existing ShopeeShopUser instance.
    /// </summary>
    public virtual ShopeeShopUser UpdateShopeeShopUser(ShopeeShopUser shopeeShopUser)
    {
      return this.Update<ShopeeShopUser>(shopeeShopUser);
    }
    
    /// <summary>
    /// Save or update an existing ShopeeShopUser instance.
    /// </summary>
    public virtual ShopeeShopUser SaveOrUpdateShopeeShopUser(ShopeeShopUser shopeeShopUser)
    {
      return this.SaveOrUpdate<ShopeeShopUser>(shopeeShopUser);
    }

    
    
    /// <summary>
    /// Get ShopeeShop by primary key.
    /// </summary>
    public virtual ShopeeShop LookupShopeeShopById(int id)
    {
      return this.LookupById<ShopeeShop>(id);
    }
    
    /// <summary>
    /// Delete ShopeeShop by primary key.
    /// </summary>
    public virtual ShopeeShop DeleteShopeeShopById(int id)
    {
      return this.DeleteById<ShopeeShop>(id);
    }
    
    /// <summary>
    /// Save a new ShopeeShop instance.
    /// </summary>
    public virtual ShopeeShop SaveShopeeShop(ShopeeShop shopeeShop)
    {
      return this.Save<ShopeeShop>(shopeeShop);
    }
    
    /// <summary>
    /// Update an existing ShopeeShop instance.
    /// </summary>
    public virtual ShopeeShop UpdateShopeeShop(ShopeeShop shopeeShop)
    {
      return this.Update<ShopeeShop>(shopeeShop);
    }
    
    /// <summary>
    /// Save or update an existing ShopeeShop instance.
    /// </summary>
    public virtual ShopeeShop SaveOrUpdateShopeeShop(ShopeeShop shopeeShop)
    {
      return this.SaveOrUpdate<ShopeeShop>(shopeeShop);
    }

    
  }
}