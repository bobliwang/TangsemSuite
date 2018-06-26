export type EditorMode = 'create' | 'view' | 'edit';

export interface SearchResultModel<T> {
	pageIndex: number;

    pageSize: number;

    rowsCount: number;

	pagedData: T[];
}

export interface SearchParams {

	pageIndex: number;

    pageSize: number;

	sortFieldName: string;

	direction: string;
}



export interface ProductModel {

     

		id?: number;


		name?: string;


		unitPrice?: number;


	
	/**
	 * TestApp.Common.Domain.ViewModels.ProductSpec[]
	 */
		specsJson?: any[];


		createdById?: number;


		createdTime?: string;


		modifiedById?: number;


		modifiedTime?: string;


		active?: boolean;


}

export interface ProductSearchParams extends ProductModel, SearchParams  {
}


export interface OrderModel {

     

		id?: number;


		customerName?: string;


		productId?: number;


		orderTotal?: number;


		createdById?: number;


		modifiedById?: number;


		createdTime?: string;


		modifiedTime?: string;


		active?: boolean;


}

export interface OrderSearchParams extends OrderModel, SearchParams  {
}


export interface PosModel {

     

		id?: number;


		name?: string;


		createdById?: number;


		modifiedById?: number;


		createdTime?: string;


		modifiedTime?: string;


		active?: boolean;


}

export interface PosSearchParams extends PosModel, SearchParams  {
}