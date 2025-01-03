import { Injectable } from '@angular/core';
import { environment } from '../../../../environment/environmemt';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ListService {

  private API_URL = environment.API_URL;

  constructor(private http: HttpClient) {}


  getAll() {
    debugger;
    const url = `${this.API_URL}/getall`;

    let obj =
    {
      page: 1,
      size: 10
    }

    return this.http.post(url, obj).pipe(
      map((data: any) => {
        return data;
      })
    );
  }
}
