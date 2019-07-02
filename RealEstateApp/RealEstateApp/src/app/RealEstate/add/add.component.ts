import { Component, OnInit } from '@angular/core';
import { RealEstateService } from '../service.service';
import { Router } from '@angular/router';
import { Http, Response } from '@angular/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';



@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  public list: [];
  realEstateForm: FormGroup;

  constructor(public http: Http,
    private _router: Router,
    private formbuiler: FormBuilder,
    private _realEstateService: RealEstateService) { }

  ngOnInit() {

    this.initalizeRealEstateFrom();
    // get list of realEstate properties
    this.getList();
  }

  // initalizing the reactive form control
  initalizeRealEstateFrom(): void {
    this.realEstateForm = this.formbuiler.group({
      area: ['', [Validators.required, Validators.maxLength(100)]],
      price: ['', Validators.required]
    })
  }

  // convenience getter for easy access to form fields
  get realEstate() { return this.realEstateForm.controls; }

  // Get list of Realestate Active member
  getList() {
    this._realEstateService.get().subscribe(
      data => this.list = data
    )
  }

  //create realestate
  onCrateProperty(): void {
    this.realEstateForm.value.active = true;
    this._realEstateService.save(this.realEstateForm.value).subscribe(
      data => {
        //once create the realEstate properties back to List view
        window.location.href = "http://localhost:50384/RealEstates";
      }
    );

  }

  //back to List
  gotoList(): void {
    window.location.href = "http://localhost:50384/RealEstates";
  }
}
