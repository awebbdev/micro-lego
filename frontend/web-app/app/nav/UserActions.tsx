'use client'

import { Button, Dropdown } from 'flowbite-react'
import { User } from 'next-auth'
import { signOut } from 'next-auth/react'
import Link from 'next/link'
import React from 'react'
import { AiFillTrophy, AiOutlineLogout } from 'react-icons/ai'
import { PiLegoDuotone } from "react-icons/pi";
import {HiCog, HiUser} from 'react-icons/hi2';

type Props = {
  user: Partial<User>
}

export default function UserActions({user}: Props) {
  return (
    <Dropdown
      inline
      label={`Welcome ${user.name}`}
    >
      <Dropdown.Item icon={HiUser}>
        <Link href='/'>
          My Auctions
        </Link>
      </Dropdown.Item>
      <Dropdown.Item icon={AiFillTrophy}>
        <Link href='/'>
          Auctions won
        </Link>
      </Dropdown.Item>
      <Dropdown.Item icon={PiLegoDuotone}>
        <Link href='/'>
          Sell a Lego Set
        </Link>
      </Dropdown.Item>
      <Dropdown.Item icon={HiCog}>
        <Link href='/session'>
          Session (dev only)
        </Link>
      </Dropdown.Item>
      <Dropdown.Divider />
      <Dropdown.Item icon={AiOutlineLogout} onClick={() => signOut({callbackUrl: '/'})}>
        Sign out
      </Dropdown.Item>
    </Dropdown>
  )
}
