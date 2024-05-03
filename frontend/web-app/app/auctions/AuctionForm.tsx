"use client";

import { Button, TextInput } from "flowbite-react";
import React, { useEffect } from "react";
import { FieldValues, useForm } from "react-hook-form";
import Input from "../components/Input";
import DateInput from "../components/DateInput";
import { usePathname, useRouter } from "next/navigation";
import { Auction } from "@/types";
import { createAuction, updateAuction } from "../actions/auctionActions";
import toast from "react-hot-toast";

type Props = {
  auction?: Auction
}

export default function AuctionForm({ auction }: Props) {

  const router = useRouter();
  const pathname = usePathname();

  const {
    control,
    handleSubmit,
    setFocus,
    reset,
    formState: { isSubmitting, isValid, isDirty, errors },
  } = useForm();

    useEffect(() => {
        if (auction) {
            const { theme, name, setNumber, pieceCount, year } = auction;
            reset({ theme, name, setNumber, pieceCount, year });
        }
        setFocus('make');
    }, [auction, reset, setFocus])

    async function onSubmit(data: FieldValues) {
      try {
          let id = '';
          let res;
          if (pathname === '/auctions/create') {
              res = await createAuction(data);
              id = res.id;
          } else {
              if (auction) {
                  res = await updateAuction(data, auction.id);
                  id = auction.id;
              }
          }
          if (res.error) {
              throw res.error;
          }
          router.push(`/auctions/details/${id}`)
      } catch (error: any) {
          toast.error(error.status + ' ' + error.message)
      }
  }

  return (
    <form className="flex flex-col mt-3" onSubmit={handleSubmit(onSubmit)}>
      <Input
        label="Theme"
        name="theme"
        control={control}
        rules={{ required: "Theme is required" }}
      />
      <Input
        label="Name"
        name="name"
        control={control}
        rules={{ required: "Name is required" }}
      />
      <Input
        label="Set Number"
        name="setNumber"
        control={control}
        rules={{ required: "Set Number is required" }}
      />

      <div className="grid grid-cols-2 gap-3">
        <Input
          label="Piece Count"
          name="pieceCount"
          control={control}
          type="number"
          rules={{ required: "Piece Count is required" }}
        />
        <Input
          label="Year"
          name="year"
          control={control}
          type="number"
          rules={{ required: "Year is required" }}
        />
      </div>
      {pathname === "/auctions/create" && (
        <>
          <Input
            label="Image URL"
            name="imageUrl"
            control={control}
            rules={{ required: "Image URL is required" }}
          />
          <div className="grid grid-cols-2 gap-3">
            <Input
              label="Reserve Price (enter 0 if no reserve)"
              name="reservePrice"
              control={control}
              type="number"
              rules={{ required: "Reserve price is required" }}
            />
            <DateInput
              label="Auction end date/time"
              name="auctionEnd"
              control={control}
              dateFormat="dd MMMM yyyy h:mm a"
              showTimeSelect
              rules={{ required: "Auction end date is required" }}
            />
          </div>
        </>
      )}

      <div className="flex justify-between">
        <Button outline color="gray">
          Cancel
        </Button>
        <Button
          isProcessing={isSubmitting}
          disabled={!isValid}
          type="submit"
          outline
          color="success"
        >
          Submit
        </Button>
      </div>
    </form>
  );
}
