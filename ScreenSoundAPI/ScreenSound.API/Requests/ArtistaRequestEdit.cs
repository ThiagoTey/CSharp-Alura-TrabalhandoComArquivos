﻿using ScreenSound.API.Requests;

public record ArtistaRequestEdit(int Id, string Nome, string Bio)
    : ArtistaRequest(Nome, Bio);