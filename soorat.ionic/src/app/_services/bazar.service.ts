import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Bazar } from '../_models/bazar';


@Injectable({
  providedIn: 'root'
})
export class BazarService {

  baseUrl = environment.apiUrl + 'bazar/';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Bazar[]> {
    return this.http.get<Bazar[]>(this.baseUrl);
  }

  get(id): Observable<Bazar> {
    return this.http.get<Bazar>(this.baseUrl  + id);
  }

  update(id: number, bazar: Bazar) {
    return this.http.put(this.baseUrl + id, bazar);
  }

  add(bazar: Bazar) {
    return this.http.post(this.baseUrl, bazar);
  }

  delete(id) {
    return this.http.delete(this.baseUrl + id);
  }

}

