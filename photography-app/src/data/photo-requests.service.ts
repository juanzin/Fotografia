import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PhotoRequestsService {

  private apiUrl: string = "https://localhost:7063/api/photos";

  constructor(private http: HttpClient) {

  }

  getPhotosByUser(id: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/${id}`);
  }

  savePhoto(id: number, photo: any): Observable<any> {
    return this.http.post(this.apiUrl, photo);
  }

}
