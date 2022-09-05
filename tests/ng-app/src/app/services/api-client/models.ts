/**
 * This is the base model for search/paging/sorting.
 */
export interface SearchResultModel<T> {
    
    pageIndex?: number;
    
    pageSize?: number;
    
    rowsCount?: number;
    
    pagedData?: T[];
    
}

/********************* ENUMs BEGIN ***************************/


export enum PropertyType {
    
        UnknownPropertyType = 0,
    
        Residential = 1,
    
        Business = 2,
    
}
    
export enum Gender {
    
        Female = 0,
    
        Male = 1,
    
        BI = 2,
    
}
    
/********************* TYPEs BEGIN ***************************/


export interface CustomerDTO {
    
    customerId?: string;
    
    customerName?: string;
    
    storeId?: number;
    
    createdById?: number;
    
    modifiedById?: number;
    
    createdTime?: string;
    
    modifiedTime?: string;
    
    active?: boolean;
    
}
     

export interface OrderDTO {
    
    id?: number;
    
    customerName?: string;
    
    productId?: number;
    
    customerId?: string;
    
    orderTotal?: number;
    
    createdById?: number;
    
    modifiedById?: number;
    
    createdTime?: string;
    
    modifiedTime?: string;
    
    active?: boolean;
    
}
     

export interface PosDTO {
    
    id?: number;
    
    name?: string;
    
    storeId?: number;
    
    createdById?: number;
    
    modifiedById?: number;
    
    createdTime?: string;
    
    modifiedTime?: string;
    
    active?: boolean;
    
}
     

export interface ProductDTO {
    
    id?: number;
    
    name?: string;
    
    unitPrice?: number;
    
    createdById?: number;
    
    createdTime?: string;
    
    modifiedById?: number;
    
    modifiedTime?: string;
    
    active?: boolean;
    
    specsJson?: ProductSpec[];
    
}
     

export interface ProductSpec {
    
    name?: string;
    
    value?: string;
    
}
     

export interface StoreDTO {
    
    id?: number;
    
    storeName?: string;
    
    storePhoto?: string;
    
    createdById?: number;
    
    createdTime?: string;
    
    modifiedById?: number;
    
    modifiedTime?: string;
    
    active?: boolean;
    
}
     

export interface Property {
    
    propertyId?: number;
    
    propertyGuidId?: string;
    
    addressLine1?: string;
    
    suburb?: string;
    
    postCode?: string;
    
    propertyType?: PropertyType;
    
    landlord?: Person;
    
    leaseStartDate?: string;
    
    leased?: boolean;
    
}
     

export interface Person {
    
    firstName?: string;
    
    lastName?: string;
    
    gender?: Gender;
    
}
     

export interface PropertyUpdatePayload {
    
    property?: Property;
    
    extraInfo?: string;
    
}
