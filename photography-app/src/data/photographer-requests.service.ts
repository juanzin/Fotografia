import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PhotographerRequestsService {

  private apiUrl: string = "https://localhost:7063/api/photographers";

  constructor(private http: HttpClient) {

  }

  getPhotographerInfo(id: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/${id}`);
  }

  updatePhotographer(id: number, photographer: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}?id=${id}`, photographer);
  }

  savePhotographer(photographer: any): Observable<any> {
    return this.http.post(this.apiUrl, photographer);
  }

  deletePhotographer(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}?id=${id}`);
  }
}
