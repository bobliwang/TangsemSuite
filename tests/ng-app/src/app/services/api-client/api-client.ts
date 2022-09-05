// tslint:disable
import { Injectable, Inject, Optional } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import * as models from './models';

/**
 * Auto-Generated client code that should not be modified manually.
 */
@Injectable({
  providedIn: 'root'
})
export class ApiClient {

  public constructor(
    private httpClient: HttpClient,
    @Optional()
    @Inject('API_URL_BASE')
    public apiUrlBase: string) {
  }

       
  /**
    * HTTP Method: get, Path: /_api/repo/Customer
    * Action: GetCustomerList, Controller: CustomerApi
    */
  public getCustomerList(qryParams?: {customerId?: string, customerName?: string, storeId?: number, createdById?: number, modifiedById?: number, createdTime?: string, modifiedTime?: string, active?: boolean, pageIndex?: number, pageSize?: number, sortFieldName?: string, direction?: string}): Observable<models.SearchResultModel<models.CustomerDTO>> {
      
      const url = this.url('/_api/repo/Customer');
            
      const params = this.getHttpParams(qryParams);
            
      return this.httpClient.get<models.SearchResultModel<models.CustomerDTO>>(url, { params });
      
  }
         
  /**
    * HTTP Method: post, Path: /_api/repo/Customer
    * Action: CreateCustomer, Controller: CustomerApi
    */
  public createCustomer(model?: models.CustomerDTO): Observable<any> {
      
      const url = this.url('/_api/repo/Customer');
                          
      return this.httpClient.post<any>(url, model);
      
  }
         
  /**
    * HTTP Method: get, Path: /_api/repo/Customer/{id}
    * Action: GetCustomerByCustomerId, Controller: CustomerApi
    */
  public getCustomerByCustomerId(id?: string): Observable<models.CustomerDTO> {
      
      const url = this.url('/_api/repo/Customer/{id}')
                .replace('{id}', `${id}`)
      ;
                  
      return this.httpClient.get<models.CustomerDTO>(url);
      
  }
         
  /**
    * HTTP Method: post, Path: /_api/repo/Customer/{id}
    * Action: UpdateCustomer, Controller: CustomerApi
    */
  public updateCustomer(id?: string, model?: models.CustomerDTO): Observable<any> {
      
      const url = this.url('/_api/repo/Customer/{id}')
                .replace('{id}', `${id}`)
      ;
                          
      return this.httpClient.post<any>(url, model);
      
  }
         
  /**
    * HTTP Method: post, Path: /_api/repo/Customer/{id}/delete
    * Action: DeleteCustomer, Controller: CustomerApi
    */
  public deleteCustomer(id?: string, qryParams?: {isHardDelete?: boolean}): Observable<any> {
      
      const url = this.url('/_api/repo/Customer/{id}/delete')
                .replace('{id}', `${id}`)
      ;
            
      const params = this.getHttpParams(qryParams);
                    
      return this.httpClient.post<any>(url, null);
      
  }
         
  /**
    * HTTP Method: get, Path: /_api/repo/Order
    * Action: GetOrderList, Controller: OrderApi
    */
  public getOrderList(qryParams?: {id?: number, customerName?: string, productId?: number, customerId?: string, orderTotal?: number, createdById?: number, modifiedById?: number, createdTime?: string, modifiedTime?: string, active?: boolean, customerIds?: string, pageIndex?: number, pageSize?: number, sortFieldName?: string, direction?: string}): Observable<models.SearchResultModel<models.OrderDTO>> {
      
      const url = this.url('/_api/repo/Order');
            
      const params = this.getHttpParams(qryParams);
            
      return this.httpClient.get<models.SearchResultModel<models.OrderDTO>>(url, { params });
      
  }
         
  /**
    * HTTP Method: post, Path: /_api/repo/Order
    * Action: CreateOrder, Controller: OrderApi
    */
  public createOrder(model?: models.OrderDTO): Observable<any> {
      
      const url = this.url('/_api/repo/Order');
                          
      return this.httpClient.post<any>(url, model);
      
  }
         
  /**
    * HTTP Method: get, Path: /_api/repo/Order/{id}
    * Action: GetOrderById, Controller: OrderApi
    */
  public getOrderById(id?: number): Observable<models.OrderDTO> {
      
      const url = this.url('/_api/repo/Order/{id}')
                .replace('{id}', `${id}`)
      ;
                  
      return this.httpClient.get<models.OrderDTO>(url);
      
  }
         
  /**
    * HTTP Method: post, Path: /_api/repo/Order/{id}
    * Action: UpdateOrder, Controller: OrderApi
    */
  public updateOrder(id?: number, model?: models.OrderDTO): Observable<any> {
      
      const url = this.url('/_api/repo/Order/{id}')
                .replace('{id}', `${id}`)
      ;
                          
      return this.httpClient.post<any>(url, model);
      
  }
         
  /**
    * HTTP Method: post, Path: /_api/repo/Order/{id}/delete
    * Action: DeleteOrder, Controller: OrderApi
    */
  public deleteOrder(id?: number, qryParams?: {isHardDelete?: boolean}): Observable<any> {
      
      const url = this.url('/_api/repo/Order/{id}/delete')
                .replace('{id}', `${id}`)
      ;
            
      const params = this.getHttpParams(qryParams);
                    
      return this.httpClient.post<any>(url, null);
      
  }
         
  /**
    * HTTP Method: get, Path: /_api/repo/Pos
    * Action: GetPosList, Controller: PosApi
    */
  public getPosList(qryParams?: {id?: number, name?: string, storeId?: number, createdById?: number, modifiedById?: number, createdTime?: string, modifiedTime?: string, active?: boolean, pageIndex?: number, pageSize?: number, sortFieldName?: string, direction?: string}): Observable<models.SearchResultModel<models.PosDTO>> {
      
      const url = this.url('/_api/repo/Pos');
            
      const params = this.getHttpParams(qryParams);
            
      return this.httpClient.get<models.SearchResultModel<models.PosDTO>>(url, { params });
      
  }
         
  /**
    * HTTP Method: post, Path: /_api/repo/Pos
    * Action: CreatePos, Controller: PosApi
    */
  public createPos(model?: models.PosDTO): Observable<any> {
      
      const url = this.url('/_api/repo/Pos');
                          
      return this.httpClient.post<any>(url, model);
      
  }
         
  /**
    * HTTP Method: get, Path: /_api/repo/Pos/{id}
    * Action: GetPosById, Controller: PosApi
    */
  public getPosById(id?: number): Observable<models.PosDTO> {
      
      const url = this.url('/_api/repo/Pos/{id}')
                .replace('{id}', `${id}`)
      ;
                  
      return this.httpClient.get<models.PosDTO>(url);
      
  }
         
  /**
    * HTTP Method: post, Path: /_api/repo/Pos/{id}
    * Action: UpdatePos, Controller: PosApi
    */
  public updatePos(id?: number, model?: models.PosDTO): Observable<any> {
      
      const url = this.url('/_api/repo/Pos/{id}')
                .replace('{id}', `${id}`)
      ;
                          
      return this.httpClient.post<any>(url, model);
      
  }
         
  /**
    * HTTP Method: post, Path: /_api/repo/Pos/{id}/delete
    * Action: DeletePos, Controller: PosApi
    */
  public deletePos(id?: number, qryParams?: {isHardDelete?: boolean}): Observable<any> {
      
      const url = this.url('/_api/repo/Pos/{id}/delete')
                .replace('{id}', `${id}`)
      ;
            
      const params = this.getHttpParams(qryParams);
                    
      return this.httpClient.post<any>(url, null);
      
  }
         
  /**
    * HTTP Method: get, Path: /_api/repo/Product
    * Action: GetProductList, Controller: ProductApi
    */
  public getProductList(qryParams?: {id?: number, name?: string, unitPrice?: number, specsJson?: string, createdById?: number, createdTime?: string, modifiedById?: number, modifiedTime?: string, active?: boolean, pageIndex?: number, pageSize?: number, sortFieldName?: string, direction?: string}): Observable<models.SearchResultModel<models.ProductDTO>> {
      
      const url = this.url('/_api/repo/Product');
            
      const params = this.getHttpParams(qryParams);
            
      return this.httpClient.get<models.SearchResultModel<models.ProductDTO>>(url, { params });
      
  }
         
  /**
    * HTTP Method: post, Path: /_api/repo/Product
    * Action: CreateProduct, Controller: ProductApi
    */
  public createProduct(model?: models.ProductDTO): Observable<any> {
      
      const url = this.url('/_api/repo/Product');
                          
      return this.httpClient.post<any>(url, model);
      
  }
         
  /**
    * HTTP Method: get, Path: /_api/repo/Product/{id}
    * Action: GetProductById, Controller: ProductApi
    */
  public getProductById(id?: number): Observable<models.ProductDTO> {
      
      const url = this.url('/_api/repo/Product/{id}')
                .replace('{id}', `${id}`)
      ;
                  
      return this.httpClient.get<models.ProductDTO>(url);
      
  }
         
  /**
    * HTTP Method: post, Path: /_api/repo/Product/{id}
    * Action: UpdateProduct, Controller: ProductApi
    */
  public updateProduct(id?: number, model?: models.ProductDTO): Observable<any> {
      
      const url = this.url('/_api/repo/Product/{id}')
                .replace('{id}', `${id}`)
      ;
                          
      return this.httpClient.post<any>(url, model);
      
  }
         
  /**
    * HTTP Method: post, Path: /_api/repo/Product/{id}/delete
    * Action: DeleteProduct, Controller: ProductApi
    */
  public deleteProduct(id?: number, qryParams?: {isHardDelete?: boolean}): Observable<any> {
      
      const url = this.url('/_api/repo/Product/{id}/delete')
                .replace('{id}', `${id}`)
      ;
            
      const params = this.getHttpParams(qryParams);
                    
      return this.httpClient.post<any>(url, null);
      
  }
         
  /**
    * HTTP Method: get, Path: /_api/repo/Store
    * Action: GetStoreList, Controller: StoreApi
    */
  public getStoreList(qryParams?: {id?: number, storeName?: string, storePhoto?: string, createdById?: number, createdTime?: string, modifiedById?: number, modifiedTime?: string, active?: boolean, pageIndex?: number, pageSize?: number, sortFieldName?: string, direction?: string}): Observable<models.SearchResultModel<models.StoreDTO>> {
      
      const url = this.url('/_api/repo/Store');
            
      const params = this.getHttpParams(qryParams);
            
      return this.httpClient.get<models.SearchResultModel<models.StoreDTO>>(url, { params });
      
  }
         
  /**
    * HTTP Method: post, Path: /_api/repo/Store
    * Action: CreateStore, Controller: StoreApi
    */
  public createStore(model?: models.StoreDTO): Observable<any> {
      
      const url = this.url('/_api/repo/Store');
                          
      return this.httpClient.post<any>(url, model);
      
  }
         
  /**
    * HTTP Method: get, Path: /_api/repo/Store/{id}
    * Action: GetStoreById, Controller: StoreApi
    */
  public getStoreById(id?: number): Observable<models.StoreDTO> {
      
      const url = this.url('/_api/repo/Store/{id}')
                .replace('{id}', `${id}`)
      ;
                  
      return this.httpClient.get<models.StoreDTO>(url);
      
  }
         
  /**
    * HTTP Method: post, Path: /_api/repo/Store/{id}
    * Action: UpdateStore, Controller: StoreApi
    */
  public updateStore(id?: number, model?: models.StoreDTO): Observable<any> {
      
      const url = this.url('/_api/repo/Store/{id}')
                .replace('{id}', `${id}`)
      ;
                          
      return this.httpClient.post<any>(url, model);
      
  }
         
  /**
    * HTTP Method: post, Path: /_api/repo/Store/{id}/delete
    * Action: DeleteStore, Controller: StoreApi
    */
  public deleteStore(id?: number, qryParams?: {isHardDelete?: boolean}): Observable<any> {
      
      const url = this.url('/_api/repo/Store/{id}/delete')
                .replace('{id}', `${id}`)
      ;
            
      const params = this.getHttpParams(qryParams);
                    
      return this.httpClient.post<any>(url, null);
      
  }
         
  /**
    * HTTP Method: get, Path: /api/Values/properties/{postCode}
    * Action: GetProperties, Controller: Values
    */
  public getProperties(postCode?: string, qryParams?: {addressLine1?: string, suburb?: string}): Observable<models.Property[]> {
      
      const url = this.url('/api/Values/properties/{postCode}')
                .replace('{postCode}', `${postCode}`)
      ;
    
      const params = this.getHttpParams(qryParams);
            
      return this.httpClient.get<models.Property[]>(url, { params });
      
  }
         
  /**
    * HTTP Method: post, Path: /api/Values/properties/{propertyId}
    * Action: UpdateProperty, Controller: Values
    */
  public updateProperty(propertyId?: number, propertyUpdatePayload?: models.PropertyUpdatePayload, qryParams?: {propertyGuidId?: string}): Observable<models.Property> {
      
      const url = this.url('/api/Values/properties/{propertyId}')
                .replace('{propertyId}', `${propertyId}`)
      ;
            
      const params = this.getHttpParams(qryParams);
                    
      return this.httpClient.post<models.Property>(url, propertyUpdatePayload, { params });
      
  }
         
  /**
    * HTTP Method: get, Path: /api/Values
    * Action: Get, Controller: Values
    */
  public getValues(): Observable<string[]> {
      
      const url = this.url('/api/Values');
                  
      return this.httpClient.get<string[]>(url);
      
  }
  

  
  protected url(relativeUrl: string): string {
      return this.apiUrlBase + relativeUrl;
  }
  
  protected setParamValue(httpParams: HttpParams, key: string, val: any): HttpParams {
      
      if (Array.isArray(val)) {
          return (val as any[]).reduce((hp, iterVal) => {
            this.setParamValue(httpParams, key, iterVal);
          }, httpParams);
      }
      
      return httpParams.append(key,  this.convertToParamValString(val));
  }

  protected convertToParamValString(val: any): string {
      if (val instanceof Date) {
        return (val as Date).toISOString();
      }

      return `${val}`;
  }

  protected getHttpParams(qryParams: any) {
      
    const params = Object.keys(qryParams || {}).reduce((p, key) => {
        if (qryParams[key] !== undefined) {
          return this.setParamValue(p, key, qryParams[key]);
        }

        return p;
      }, new HttpParams());

    return params;
  }

}
