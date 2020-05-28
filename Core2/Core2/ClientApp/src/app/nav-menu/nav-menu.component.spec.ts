import { async, ComponentFixture, TestBed, inject, tick, fakeAsync } from '@angular/core/testing';
import { DebugElement } from '@angular/core';
import { By } from '@angular/platform-browser';

import { NavMenuComponent } from './nav-menu.component';

describe('NavMenuComponent' , () => {
    let component: NavMenuComponent;
    let fixture: ComponentFixture<NavMenuComponent>;
    let de: DebugElement;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [NavMenuComponent]
        })
        .compileComponents();
    }
    ));

    beforeEach(() => {
        fixture = TestBed.createComponent(NavMenuComponent);
        component = fixture.componentInstance;
        de = fixture.debugElement;

        fixture.detectChanges();
    });

    it ('should create', () => {
        expect(component).toBeTruthy();
    });
});

