import { Auction } from '@/types'
import React from 'react'
import CountdownTimer from './CountdownTimer'
import SetImage from './SetImage'

type Props = {
    auction: Auction
}

export default function AuctionCard({ auction } : Props) {
  return (
    <a href='#'>
        <div className='w-full bg-gray-200 aspect-w-16 aspect-h-10 rounded-lg overflow-hidden'>
            <div>
                <SetImage imageUrl={auction.imageUrl} />
                <div className='absolute bottom-2 left-2'>
                    <CountdownTimer auctionEnd={auction.auctionEnd} />
                </div>
            </div>
        </div>
        <div className='flex justify-between items-center mt-4'>
            <h3 className='text-gray-700'>{auction.theme} {auction.name}</h3>
            <p className='font-semibold text-sm'>{auction.setNumber}</p>
        </div>
    </a>
  )
}
