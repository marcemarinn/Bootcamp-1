﻿using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Requests;
using Infrastructure.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BankRepository : IBankRepository
{
    private readonly Bootcampp2Context _context;

    public BankRepository(Bootcampp2Context context)
    {
        _context = context;
    }

    public async Task<BankDTO> Add(CreateBankModel model)
    {
        var bankToCreate = model.Adapt<Bank>();

        _context.Banks.Add(bankToCreate);

        await _context.SaveChangesAsync();

        var bankDTO = bankToCreate.Adapt<BankDTO>();

        return bankDTO;
    }

    public async Task<bool> Delete(int id)
    {
        var bank = await _context.Banks.FindAsync(id);

        if (bank is null) throw new Exception("Bank not found");

        _context.Banks.Remove(bank);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<List<BankDTO>> GetAll()
    {
        var banks = await _context.Banks.ToListAsync();

        var banksDTO = banks.Adapt<List<BankDTO>>();

        return banksDTO;
    }

    public async Task<BankDTO> GetById(int id)
    {

        //throw new Exception("No se pudo conectar a la base de datos");
        var bank = await _context.Banks.FindAsync(id);

        //if (bank is null) throw new Exception("Bank not found");
        if (bank is null)
        throw new NotFoundException($"Bank with id: {id} doest not exist"); 

        var bankDTO = bank.Adapt<BankDTO>();

        return bankDTO;
    }

    public async Task<bool> NameIsAlreadyTaken(string name)
    {

        return await _context.Banks.AnyAsync(bank => bank.Name == name);
        //throw new NameIsAlreadyTakenException($"Bank with Name: {name} is already taken");
    }

    public async Task<BankDTO> Update(UpdateBankModel model)
    {
        var bank = await _context.Banks.FindAsync(model.Id);

        if (bank is null) throw new Exception("Bank was not found");

        model.Adapt(bank);

        _context.Banks.Update(bank);

        await _context.SaveChangesAsync();

        var bankDTO = bank.Adapt<BankDTO>();

        return bankDTO;
    }
}
