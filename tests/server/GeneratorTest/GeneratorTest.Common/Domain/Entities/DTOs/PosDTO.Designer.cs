using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace GeneratorTest.Common.Domain.Entities.DTOs
{
  public partial class PosDTO
  {	
    /// <summary>
    /// The default constructor for PosDTO class.
    /// </summary>
    public PosDTO()
    {
    }

        /// <summary>
    /// Property Id mapping to Pos.Id
    /// </summary>
    public virtual int Id { get; set; }
    
        /// <summary>
    /// Property Name mapping to Pos.Name
    /// </summary>
    public virtual string Name { get; set; }
    
        /// <summary>
    /// Property StoreId mapping to Pos.StoreId
    /// </summary>
    public virtual int? StoreId { get; set; }
    
        /// <summary>
    /// Property CreatedById mapping to Pos.CreatedById
    /// </summary>
    public virtual int? CreatedById { get; set; }
    
        /// <summary>
    /// Property ModifiedById mapping to Pos.ModifiedById
    /// </summary>
    public virtual int? ModifiedById { get; set; }
    
        /// <summary>
    /// Property CreatedTime mapping to Pos.CreatedTime
    /// </summary>
    public virtual System.DateTime? CreatedTime { get; set; }
    
        /// <summary>
    /// Property ModifiedTime mapping to Pos.ModifiedTime
    /// </summary>
    public virtual System.DateTime? ModifiedTime { get; set; }
    
        /// <summary>
    /// Property Active mapping to Pos.Active
    /// </summary>
    public virtual bool Active { get; set; }
    
    
    
  }
}