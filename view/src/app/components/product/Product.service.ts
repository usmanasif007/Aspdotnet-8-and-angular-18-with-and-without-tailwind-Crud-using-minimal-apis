import { Injectable } from '@angular/core'
import { HttpClient, HttpParams } from '@angular/common/http'
import { map, Observable } from 'rxjs'
import { environment } from '../../../environment/environmemt';
import { ProductFilterDTO } from './list/list.component';

@Injectable({
  providedIn: 'root'
})

export class ProductService {
  
  constructor(private http: HttpClient) { }

  // saveObj(url: any, obj: any): Observable<any> {
  //   const params = new HttpParams({ fromObject: obj });

  //   var param = params.toString();
  //   return this.http.post(`${API_URL}/${url}?${params.toString()}`, obj)
  // }


  public getDataById(filter: ProductFilterDTO): Observable<any> {
    const url = `/product/getAll`;
    return this.http.post<any>(url, filter);
  }
  

  getAll() : Observable<any> {
    debugger;
    const url = `${environment.API_URL}/product/getAll`;
    let obj =
    {
      page: 1,
      size: 10
    }
    const params = new HttpParams({ fromObject: obj });
    var param = params.toString();
    return this.http.post<any>(`${url}`, param);
  }

  public getData(url: any): Observable<any> {
    return this.http.get<any>(`${environment.API_URL}/${url}`);
  }

  saveData(url: any, obj: any): Observable<any>{
    return this.http.post<any>(`${environment.API_URL}/${url}`, obj);
  }

  get(id?: any): Observable<any> {
    if (id) {
      return this.http.get(`/products/${id}`)
    }
    else {
      return this.http.get('/products/getAll' + location.search)
    }
  }

  create(data?: any): Observable<any> {
    if (data) {
      return this.http.post('/products', data)
    }
    else {
      return this.http.get('/products/create')
    }
  }

  edit(id: any, data?: any): Observable<any> {
    if (data) {
      return this.http.put(`/products/${id}`, data)
    }
    else {
      return this.http.get(`/products/${id}`)
    }
  }

  delete(id: any, data?: any): Observable<any> {
    if (data) {
      return this.http.delete(`/products/${id}`)
    }
    else {
      return this.http.get(`/products/${id}`)
    }
  }
}