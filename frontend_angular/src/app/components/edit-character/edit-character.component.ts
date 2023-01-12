import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {SuitsCharacter} from "../../models/suits-character";
import {SuitsCharacterService} from "../../services/suits-character.service";

@Component({
  selector: 'app-edit-character',
  templateUrl: './edit-character.component.html',
  styleUrls: ['./edit-character.component.css']
})
export class EditCharacterComponent implements OnInit {
  @Input() character?: SuitsCharacter;
  @Output() characterUpdated = new EventEmitter<SuitsCharacter[]>();

  constructor(private suitsCharacterService: SuitsCharacterService) { }

  ngOnInit(): void { }

  updateCharacter(character:SuitsCharacter){
    this.suitsCharacterService
      .updateSuitsCharacters(character)
      .subscribe((characters) => this.characterUpdated.emit(characters));
  }

  deleteCharacter(character:SuitsCharacter){
    this.suitsCharacterService
      .deleteSuitsCharacters(character)
      .subscribe((characters) => this.characterUpdated.emit(characters));
  }

  createCharacter(character:SuitsCharacter){
    this.suitsCharacterService
      .createSuitsCharacters(character)
      .subscribe((characters) => this.characterUpdated.emit(characters));
  }

}
