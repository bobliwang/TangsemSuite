import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import * as models from '../models/models';

export class GeneratorTestRepositoryApiService {

    constructor(protected httpClient: HttpClient) {
    }



     
     public getProductList(filterModel: models.ProductSearchParams): Observable<models.SearchResultModel<models.ProductModel>> {
		const searchParams = this.populateProductSearchParams(filterModel);

        return this.httpClient.get<models.SearchResultModel<models.ProductModel>>(`_api/repo/Product`, { params: searchParams });
     }
     
     public getProductById(id: number | string): Observable<models.ProductModel> {
        return this.httpClient.get<models.ProductModel>(`_api/repo/Product/${id}`);
     }
     
     public updateProduct(id: number | string, model: models.ProductModel): Observable<any> {
        return this.httpClient.post<any>(`_api/repo/Product/${id}`, model);
     }
     
     public createProduct(model: models.ProductModel): Observable<models.ProductModel> {
        return this.httpClient.post<any>(`_api/repo/Product`, model);
     }

	 public deleteProduct(id: number | string): Observable<any> {
        return this.httpClient.post<any>(`_api/repo/Product/delete/${id}`, {});
     }

	 protected populateProductSearchParams(filterModel: models.ProductSearchParams): HttpParams {
		

		let params = new HttpParams();

		if (filterModel) {
			params = params.set('sortFieldName', filterModel.sortFieldName)
						   .set('direction', filterModel.direction)
						   .set('pageIndex', filterModel.pageIndex.toString())
						   .set('pageSize', filterModel.pageSize.toString());

			
			if (filterModel.id)
			{
				params = params.set('id', filterModel.id.toString());

			}
			
			if (filterModel.name)
			{
				params = params.set('name', filterModel.name.toString());

			}
			
			if (filterModel.unitPrice)
			{
				params = params.set('unitPrice', filterModel.unitPrice.toString());

			}
			
			if (filterModel.specsJson)
			{
				params = params.set('specsJson', filterModel.specsJson.toString());

			}
			
			if (filterModel.createdById)
			{
				params = params.set('createdById', filterModel.createdById.toString());

			}
			
			if (filterModel.createdTime)
			{
				params = params.set('createdTime', filterModel.createdTime.toString());

			}
			
			if (filterModel.modifiedById)
			{
				params = params.set('modifiedById', filterModel.modifiedById.toString());

			}
			
			if (filterModel.modifiedTime)
			{
				params = params.set('modifiedTime', filterModel.modifiedTime.toString());

			}
			
			if (filterModel.active)
			{
				params = params.set('active', filterModel.active.toString());

			}
			
		}

		return params;
	 }


 
     
     public getOrderList(filterModel: models.OrderSearchParams): Observable<models.SearchResultModel<models.OrderModel>> {
		const searchParams = this.populateOrderSearchParams(filterModel);

        return this.httpClient.get<models.SearchResultModel<models.OrderModel>>(`_api/repo/Order`, { params: searchParams });
     }
     
     public getOrderById(id: number | string): Observable<models.OrderModel> {
        return this.httpClient.get<models.OrderModel>(`_api/repo/Order/${id}`);
     }
     
     public updateOrder(id: number | string, model: models.OrderModel): Observable<any> {
        return this.httpClient.post<any>(`_api/repo/Order/${id}`, model);
     }
     
     public createOrder(model: models.OrderModel): Observable<models.OrderModel> {
        return this.httpClient.post<any>(`_api/repo/Order`, model);
     }

	 public deleteOrder(id: number | string): Observable<any> {
        return this.httpClient.post<any>(`_api/repo/Order/delete/${id}`, {});
     }

	 protected populateOrderSearchParams(filterModel: models.OrderSearchParams): HttpParams {
		

		let params = new HttpParams();

		if (filterModel) {
			params = params.set('sortFieldName', filterModel.sortFieldName)
						   .set('direction', filterModel.direction)
						   .set('pageIndex', filterModel.pageIndex.toString())
						   .set('pageSize', filterModel.pageSize.toString());

			
			if (filterModel.id)
			{
				params = params.set('id', filterModel.id.toString());

			}
			
			if (filterModel.customerName)
			{
				params = params.set('customerName', filterModel.customerName.toString());

			}
			
			if (filterModel.productId)
			{
				params = params.set('productId', filterModel.productId.toString());

			}
			
			if (filterModel.orderTotal)
			{
				params = params.set('orderTotal', filterModel.orderTotal.toString());

			}
			
			if (filterModel.createdById)
			{
				params = params.set('createdById', filterModel.createdById.toString());

			}
			
			if (filterModel.modifiedById)
			{
				params = params.set('modifiedById', filterModel.modifiedById.toString());

			}
			
			if (filterModel.createdTime)
			{
				params = params.set('createdTime', filterModel.createdTime.toString());

			}
			
			if (filterModel.modifiedTime)
			{
				params = params.set('modifiedTime', filterModel.modifiedTime.toString());

			}
			
			if (filterModel.active)
			{
				params = params.set('active', filterModel.active.toString());

			}
			
		}

		return params;
	 }


 
     
     public getPosList(filterModel: models.PosSearchParams): Observable<models.SearchResultModel<models.PosModel>> {
		const searchParams = this.populatePosSearchParams(filterModel);

        return this.httpClient.get<models.SearchResultModel<models.PosModel>>(`_api/repo/Pos`, { params: searchParams });
     }
     
     public getPosById(id: number | string): Observable<models.PosModel> {
        return this.httpClient.get<models.PosModel>(`_api/repo/Pos/${id}`);
     }
     
     public updatePos(id: number | string, model: models.PosModel): Observable<any> {
        return this.httpClient.post<any>(`_api/repo/Pos/${id}`, model);
     }
     
     public createPos(model: models.PosModel): Observable<models.PosModel> {
        return this.httpClient.post<any>(`_api/repo/Pos`, model);
     }

	 public deletePos(id: number | string): Observable<any> {
        return this.httpClient.post<any>(`_api/repo/Pos/delete/${id}`, {});
     }

	 protected populatePosSearchParams(filterModel: models.PosSearchParams): HttpParams {
		

		let params = new HttpParams();

		if (filterModel) {
			params = params.set('sortFieldName', filterModel.sortFieldName)
						   .set('direction', filterModel.direction)
						   .set('pageIndex', filterModel.pageIndex.toString())
						   .set('pageSize', filterModel.pageSize.toString());

			
			if (filterModel.id)
			{
				params = params.set('id', filterModel.id.toString());

			}
			
			if (filterModel.name)
			{
				params = params.set('name', filterModel.name.toString());

			}
			
			if (filterModel.createdById)
			{
				params = params.set('createdById', filterModel.createdById.toString());

			}
			
			if (filterModel.modifiedById)
			{
				params = params.set('modifiedById', filterModel.modifiedById.toString());

			}
			
			if (filterModel.createdTime)
			{
				params = params.set('createdTime', filterModel.createdTime.toString());

			}
			
			if (filterModel.modifiedTime)
			{
				params = params.set('modifiedTime', filterModel.modifiedTime.toString());

			}
			
			if (filterModel.active)
			{
				params = params.set('active', filterModel.active.toString());

			}
			
		}

		return params;
	 }


 
}