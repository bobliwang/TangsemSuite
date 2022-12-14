// tslint:disable
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import * as models from '../models/models';

@Injectable()
export class GeneratorTestRepositoryApiService {

	private _apiBaseUrl = '';

    constructor(protected httpClient: HttpClient) {
    }

	public setApiBaseUrl(val: string) {
		this._apiBaseUrl = val;
	}

	public url(path: string) {
		return `${this._apiBaseUrl}/${path}`;
	}

    
	public updateSearchParams(params: HttpParams, filterModel: any): HttpParams {
        filterModel.sortFieldName = filterModel.sortFieldName || '';
        filterModel.direction = filterModel.direction || '';
        filterModel.pageIndex = filterModel.pageIndex || 0;
        filterModel.pageSize = filterModel.pageSize || 0;
        
		params = params.set('sortFieldName', filterModel.sortFieldName)
						.set('direction', filterModel.direction)
						.set('pageIndex', filterModel.pageIndex.toString())
						.set('pageSize', filterModel.pageSize.toString());

	    Object.keys(filterModel).forEach(keyName => {
		    if (filterModel[keyName] != null) {
			    params = params.set(keyName, filterModel[keyName].toString());
		    }
	    });

	    return params;
	}



     
     public getCustomerList(filterModel: models.CustomerSearchParams): Observable<models.SearchResultModel<models.CustomerModel>> {
		const searchParams = this.populateCustomerSearchParams(filterModel);

        return this.httpClient.get<models.SearchResultModel<models.CustomerModel>>(this.url(`_api/repo/Customer`), { params: searchParams });
     }
     
     public getCustomerByCustomerId(id: number | string): Observable<models.CustomerModel> {
        return this.httpClient.get<models.CustomerModel>(this.url(`_api/repo/Customer/${id}`));
     }
     
     public updateCustomer(id: number | string, model: models.CustomerModel): Observable<any> {
        return this.httpClient.post<any>(this.url(`_api/repo/Customer/${id}`), model);
     }
     
     public createCustomer(model: models.CustomerModel): Observable<models.CustomerModel> {
        return this.httpClient.post<any>(this.url(`_api/repo/Customer`), model);
     }

	 public deleteCustomer(id: number | string): Observable<any> {
        return this.httpClient.post<any>(this.url(`_api/repo/Customer/${id}/delete`), {});
     }

	 protected populateCustomerSearchParams(filterModel: models.CustomerSearchParams): HttpParams {
		

		let params = new HttpParams();

		if (filterModel) {            
            params = this.updateSearchParams(params, filterModel);
		}

		return params;
	 }


 
     
     public getStoreList(filterModel: models.StoreSearchParams): Observable<models.SearchResultModel<models.StoreModel>> {
		const searchParams = this.populateStoreSearchParams(filterModel);

        return this.httpClient.get<models.SearchResultModel<models.StoreModel>>(this.url(`_api/repo/Store`), { params: searchParams });
     }
     
     public getStoreById(id: number | string): Observable<models.StoreModel> {
        return this.httpClient.get<models.StoreModel>(this.url(`_api/repo/Store/${id}`));
     }
     
     public updateStore(id: number | string, model: models.StoreModel): Observable<any> {
        return this.httpClient.post<any>(this.url(`_api/repo/Store/${id}`), model);
     }
     
     public createStore(model: models.StoreModel): Observable<models.StoreModel> {
        return this.httpClient.post<any>(this.url(`_api/repo/Store`), model);
     }

	 public deleteStore(id: number | string): Observable<any> {
        return this.httpClient.post<any>(this.url(`_api/repo/Store/${id}/delete`), {});
     }

	 protected populateStoreSearchParams(filterModel: models.StoreSearchParams): HttpParams {
		

		let params = new HttpParams();

		if (filterModel) {            
            params = this.updateSearchParams(params, filterModel);
		}

		return params;
	 }


 
     
     public getOrderList(filterModel: models.OrderSearchParams): Observable<models.SearchResultModel<models.OrderModel>> {
		const searchParams = this.populateOrderSearchParams(filterModel);

        return this.httpClient.get<models.SearchResultModel<models.OrderModel>>(this.url(`_api/repo/Order`), { params: searchParams });
     }
     
     public getOrderById(id: number | string): Observable<models.OrderModel> {
        return this.httpClient.get<models.OrderModel>(this.url(`_api/repo/Order/${id}`));
     }
     
     public updateOrder(id: number | string, model: models.OrderModel): Observable<any> {
        return this.httpClient.post<any>(this.url(`_api/repo/Order/${id}`), model);
     }
     
     public createOrder(model: models.OrderModel): Observable<models.OrderModel> {
        return this.httpClient.post<any>(this.url(`_api/repo/Order`), model);
     }

	 public deleteOrder(id: number | string): Observable<any> {
        return this.httpClient.post<any>(this.url(`_api/repo/Order/${id}/delete`), {});
     }

	 protected populateOrderSearchParams(filterModel: models.OrderSearchParams): HttpParams {
		

		let params = new HttpParams();

		if (filterModel) {            
            params = this.updateSearchParams(params, filterModel);
		}

		return params;
	 }


 
     
     public getProductList(filterModel: models.ProductSearchParams): Observable<models.SearchResultModel<models.ProductModel>> {
		const searchParams = this.populateProductSearchParams(filterModel);

        return this.httpClient.get<models.SearchResultModel<models.ProductModel>>(this.url(`_api/repo/Product`), { params: searchParams });
     }
     
     public getProductById(id: number | string): Observable<models.ProductModel> {
        return this.httpClient.get<models.ProductModel>(this.url(`_api/repo/Product/${id}`));
     }
     
     public updateProduct(id: number | string, model: models.ProductModel): Observable<any> {
        return this.httpClient.post<any>(this.url(`_api/repo/Product/${id}`), model);
     }
     
     public createProduct(model: models.ProductModel): Observable<models.ProductModel> {
        return this.httpClient.post<any>(this.url(`_api/repo/Product`), model);
     }

	 public deleteProduct(id: number | string): Observable<any> {
        return this.httpClient.post<any>(this.url(`_api/repo/Product/${id}/delete`), {});
     }

	 protected populateProductSearchParams(filterModel: models.ProductSearchParams): HttpParams {
		

		let params = new HttpParams();

		if (filterModel) {            
            params = this.updateSearchParams(params, filterModel);
		}

		return params;
	 }


 
     
     public getPosList(filterModel: models.PosSearchParams): Observable<models.SearchResultModel<models.PosModel>> {
		const searchParams = this.populatePosSearchParams(filterModel);

        return this.httpClient.get<models.SearchResultModel<models.PosModel>>(this.url(`_api/repo/Pos`), { params: searchParams });
     }
     
     public getPosById(id: number | string): Observable<models.PosModel> {
        return this.httpClient.get<models.PosModel>(this.url(`_api/repo/Pos/${id}`));
     }
     
     public updatePos(id: number | string, model: models.PosModel): Observable<any> {
        return this.httpClient.post<any>(this.url(`_api/repo/Pos/${id}`), model);
     }
     
     public createPos(model: models.PosModel): Observable<models.PosModel> {
        return this.httpClient.post<any>(this.url(`_api/repo/Pos`), model);
     }

	 public deletePos(id: number | string): Observable<any> {
        return this.httpClient.post<any>(this.url(`_api/repo/Pos/${id}/delete`), {});
     }

	 protected populatePosSearchParams(filterModel: models.PosSearchParams): HttpParams {
		

		let params = new HttpParams();

		if (filterModel) {            
            params = this.updateSearchParams(params, filterModel);
		}

		return params;
	 }


 
}