'use client'

import { Button, Dropdown } from 'flowbite-react'
import { User } from 'next-auth'
import { signOut } from 'next-auth/react'
import Link from 'next/link'
import React from 'react'
import { AiFillTrophy, AiOutlineLogout } from 'react-icons/ai'
import { PiLegoDuotone } from "react-icons/pi";
import {HiCog, HiUser} from 'react-icons/hi2';
import { usePathname, useRouter } from 'next/navigation'
import { useParamsStore } from '@/hooks/useParamsStore'

type Props = {
  user: User
}

export default function UserActions({user}: Props) {
  const router = useRouter();
  const pathname = usePathname();
  const setParams = useParamsStore(state => state.setParams);

  function setWinner() {
    setParams({winner: user.username, seller: undefined})
    if (pathname !== '/') router.push('/');
  }

  function setSeller() {
    setParams({seller: user.username, winner: undefined})
    if (pathname !== '/') router.push('/');
  }

  return (
    <Dropdown
      inline
      label={`Welcome ${user.name}`}
    >
      <Dropdown.Item icon={HiUser} onClick={setSeller}>
          My Auctions
      </Dropdown.Item>
      <Dropdown.Item icon={AiFillTrophy} onClick={setWinner}>
          Auctions won
      </Dropdown.Item>
      <Dropdown.Item icon={PiLegoDuotone}>
        <Link href='/auctions/create'>
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
